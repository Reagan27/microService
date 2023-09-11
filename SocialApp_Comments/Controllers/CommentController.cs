using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicroService_Comments.Models;
using MicroService_Comments.Models.DTOs;
using MicroService_Comments.Services.IServices;
using System.Data;

namespace MicroService_Comments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentsService _commentInterface;
        private readonly IMapper _mapper;
        private readonly ResponseDTO _response;

        public CommentController(ICommentsService commentsService, IMapper mapper )
        {
            _commentInterface = commentsService;
            _mapper = mapper;
            _response = new ResponseDTO();
            
        }
        // create comment
        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> CreateComment(CommentsRequestDTO commentRequestDto)
        {
            var newComment = _mapper.Map<Comment>(commentRequestDto);
            var response = await _commentInterface.CreateCommentAsync(newComment);
            if (response != null)
            {
                _response.IsSuccess = true;
                _response.Message = response;
                return Ok(_response);
            }
            _response.IsSuccess = false;
            _response.Message = "Something went wrong";
            return BadRequest(_response);
        }

        // get all comments
        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAllComments()
        {
            var comments = await _commentInterface.GetAllCommentsAsync();
            if (comments != null)
            {
                _response.Message = "";
                _response.IsSuccess = true;
                _response.Data = comments;
                return Ok(_response);
            }
            _response.IsSuccess = false;
            _response.Message = "Something went wrong";
            return BadRequest(_response);
        }

        // get comment by id
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO>> GetCommentById(Guid id)
        {
            var comment = await _commentInterface.GetCommentByIdAsync(id);
            if (comment != null)
            {
                _response.IsSuccess = true;
                _response.Message = "";
                _response.Data = comment;
                return Ok(_response);
            }
            _response.IsSuccess = false;
            _response.Message = "Something went wrong";
            return BadRequest(_response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseDTO>> DeleteComment(Guid commentId)
        {
            var comment = await _commentInterface.GetCommentByIdAsync(commentId);
            if (comment != null)
            {
                var response = await _commentInterface.DeleteCommentAsync(comment);
                if (response != null)
                {
                    _response.IsSuccess = true;
                    _response.Message = "Successfully deleted";
                    return Ok(_response);
                }
                _response.IsSuccess = false;
                _response.Message = "Something went wrong";
                return BadRequest(_response);
            }
            _response.IsSuccess = false;
            _response.Message = "Comment not found";
            return BadRequest(_response);
        }


        // update comment by id
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseDTO>> UpdateComment(Guid id, CommentsRequestDTO commentRequestDto)
        {
            var comment = await _commentInterface.GetCommentByIdAsync(id);
            if (comment == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Comment not found";
                return BadRequest(_response);
            }
            var updatedComment = _mapper.Map(commentRequestDto, comment);
            var response = await _commentInterface.UpdateCommentAsync(updatedComment);
            if (response != null)
            {
                _response.IsSuccess = true;
                _response.Message = response;
                return Ok(_response);
            }
            _response.IsSuccess = false;
            _response.Message = "Something went wrong";
            return BadRequest(_response);


        }
        // Get All Comments by ID
        [HttpGet("GetAllCommentsByPostId/{id}")]
        public async Task<ActionResult<ResponseDTO>> GetAllCommentsByPostId(Guid id)
        {
            var comments = await _commentInterface.GetCommentsByPostIdAsync(id);
            if (comments != null)
            {
                _response.Message = "";
                _response.IsSuccess = true;
                _response.Data = comments;
                return Ok(_response);
            }
            _response.IsSuccess = false;
            _response.Message = "Something went wrong";
            return BadRequest(_response);
        }

        [HttpGet("GetCommentBy/{id}")]
        public async Task<ActionResult<ResponseDTO>> GetAllCommentsByUserId(string userId)
        {
            var comments = await _commentInterface.GetCommentsByUserIdAsync(userId);
            if (comments != null)
            {
                _response.Message = "";
                _response.IsSuccess = true;
                _response.Data = comments;
                return Ok(_response);
            }
            _response.IsSuccess = false;
            _response.Message = "Something went wrong";
            return BadRequest(_response);
        }
    }

    
}
