using AutoMapper;
using Post_Coments_Api.Comments.Dtos;
using Post_Coments_Api.Comments.Model;
using Post_Coments_Api.Posts.Dtos;
using Post_Coments_Api.Posts.Repository;
using Post_Coments_Api.Posts.Exceptions;
using Post_Coments_Api.Posts.Model;
using Microsoft.AspNetCore.Server.IIS.Core;
using Post_Coments_Api.Comments.Exceptions;
using System.CodeDom;

namespace Post_Coments_Api.Posts.Services
{
    public class CommandServicePost:ICommandServicePost
    {
        private readonly IPostRepo _repo;
        private readonly IMapper _mapper;

        public CommandServicePost(IPostRepo repo,IMapper mapper)
        {
            this._mapper = mapper;
            this._repo = repo;
        }


        public async Task<PostResponse> CreatePostAsyc(PostRequest create)
        {
            PostResponse vf = await _repo.FindByNamePostAsync(create.Title);

            if (vf == null)
            {

                PostResponse response = await _repo.CreatePostAsyc(create);

                return response;


            }
            throw new PostAlreadyExistExceptions();






        }

        public async Task<CommentResponse> AddCommentAsync(CommentRequest comentrequest)
        {
            var post = await _repo.GetEntityByIdAsync(comentrequest.Post_id);
            if (post == null)
                throw new PostNotFoundException();

            var comment = _mapper.Map<Comment>(comentrequest);
            comment.Created = DateTime.UtcNow;

            post.Comments.Add(comment);

            await _repo.UpdateAsync(post);

            return _mapper.Map<CommentResponse>(post);





        }

        public async Task<PostResponse> UpdatePostsAsync(int id, PostUpdateRequest update)
        {
            PostResponse verf = await _repo.FindByIdAsync(id);

            if (verf != null)
            {
                if(verf is PostRequest)
                {
                    verf.Title = update.Title ?? verf.Title;
                    verf.Content = update.Content ?? verf.Content;
                    verf.Created_Post = update.Created_Post ?? verf.Created_Post;
                    verf.Update_Post = update.Update_Post ?? verf.Update_Post;

                    PostResponse response = await this.UpdatePostsAsync(id, update);
                    return response;


                }



            }

            throw new PostNotFoundException();







        }

        public async Task<PostResponse> DeletePostAsync(int id)
        {

            PostResponse verf = await _repo.FindByIdAsync(id);

            if (verf != null)
            {
                PostResponse response = await _repo.DeletePostAsync(id);

                return response;
            }
            throw new PostNotFoundException();







        }

        public async Task<CommentResponse> DeleteCommentAsync(int idpost, int idcomment)
        {
            Post post = await _repo.GetEntityByIdAsync(idpost);

            Comment comment = post.Comments.FirstOrDefault(s => s.Id == idcomment);

            if(post != null)
            {
                if (comment != null)
                {


                    CommentResponse response = await _repo.DeleteCommentAsync(idpost, idcomment);
                    return response;




                }
                throw new CommentNotFoundException();

            }
            throw new PostNotFoundException();




        }










    }
}
