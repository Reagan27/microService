using AutoMapper;
using MicroService_Comments.Models;
using MicroService_Comments.Models.DTOs;

namespace MicroService_Comments.Profiles
{
    public class CommentProfiles : Profile
    {
        public CommentProfiles()
        {
            CreateMap<CommentsRequestDTO, Comment>().ReverseMap();

        }
       
    }
}
