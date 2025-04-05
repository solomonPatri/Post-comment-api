using Post_Coments_Api.Comments.Dtos;
using Post_Coments_Api.Posts.Dtos;

namespace Post_Coments_Api.Posts.Services
{
    public interface ICommandServicePost
    {

        Task<PostResponse> CreatePostAsyc(PostRequest create);

        Task<CommentResponse> AddCommentAsync(CommentRequest comentrequest);

        Task<PostResponse> UpdatePostsAsync(int id, PostUpdateRequest update);

        Task<PostResponse> DeletePostAsync(int id);

        Task<CommentResponse> DeleteCommentAsync(int idpost, int idcomment);









    }
}
