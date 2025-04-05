using AutoMapper;
using FluentMigrator.Builder.Create.Index;
using Post_Coments_Api.Comments.Model;
using Post_Coments_Api.Comments.Dtos;
using Post_Coments_Api.Comments.Dtos;
using Post_Coments_Api.Posts.Model;

namespace Post_Coments_Api.Comments.Mappers
{
    public class CommentMappingProfile:Profile
    {

        public CommentMappingProfile()
        {

            CreateMap<CommentRequest, Comment>();
            CreateMap<Comment, CommentResponse>();


        }







    }
}
