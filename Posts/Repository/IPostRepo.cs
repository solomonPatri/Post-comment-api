using Post_Coments_Api.Posts.Dtos;
using Post_Coments_Api.Posts.Model;
using Post_Coments_Api.Comments.Dtos;

namespace Post_Coments_Api.Posts.Repository
{
    public interface IPostRepo
    {

        Task<GetAllPostsDtos> GetAllPostsAsync();

        Task<PostResponse> CreatePostAsyc(PostRequest create);

        Task<PostResponse> GetByIdAsync(int id);

        Task<Post?> GetEntityByIdAsync(int id);

        Task<PostResponse> UpdateAsync(int id, PostUpdateRequest update);

        Task<PostResponse> FindByNamePostAsync(string name);


        Task<PostResponse> FindByIdAsync(int id);

        Task UpdateAsync(Post post);

        Task<PostResponse> DeletePostAsync(int id);


        Task<CommentResponse> DeleteCommentAsync(int idpost, int idcomment); 








    }
}
