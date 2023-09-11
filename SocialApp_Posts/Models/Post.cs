using Microsoft.AspNetCore.Identity;
using MicroService_Posts.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroService_Posts.Models
{
    public class Post
    {
        [Key]
        public Guid PostId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [NotMapped]
        public IEnumerable<CommentDTO>? Comments { get; set; }
    }
}