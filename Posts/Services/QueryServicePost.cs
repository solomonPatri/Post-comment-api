using Post_Coments_Api.Posts.Repository;
using System.Diagnostics.SymbolStore;
using Post_Coments_Api.Posts.Exceptions;
using Post_Coments_Api.Posts.Model;
using Post_Coments_Api.Posts.Dtos;

namespace Post_Coments_Api.Posts.Services
{
    public class QueryServicePost:IQueryServicePost
    {

        private readonly IPostRepo _repo;
       

        public QueryServicePost(IPostRepo repo)
        {
            _repo = repo;

        }



       public async  Task<GetAllPostsDtos> GetAllPosts()
        {
            GetAllPostsDtos response = await _repo.GetAllPostsAsync();

            if (response != null){

                return response;
            
            }

            throw new PostNotFoundException();


        }











    }
}
