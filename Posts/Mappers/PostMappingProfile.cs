using AutoMapper;
using Post_Coments_Api.Posts.Dtos;
using Post_Coments_Api.Posts.Model;
namespace Post_Coments_Api.Posts.Mappers
{
    public class PostMappingProfile:Profile
    {


        public PostMappingProfile()
        {

            CreateMap<PostRequest, Post>();
            CreateMap<Post, PostResponse>();
            CreateMap<PostUpdateRequest, Post>();


            CreateMap<Post, PostResponse>()
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));




        }
























    }
}
