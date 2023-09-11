using AutoMapper;
using MicroService_Posts.Models;
using MicroService_Posts.Models.DTOs;

namespace MicroService_Posts.Profiles
{
    public class PostProfiles : Profile
    {

        public PostProfiles()
        {
            CreateMap<ResponseDTO, Post>().ReverseMap();
            CreateMap<PostRequestDTO, Post>().ReverseMap();    
        }
    }
}
