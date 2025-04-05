using Post_Coments_Api.Systems;
namespace Post_Coments_Api.Posts.Exceptions
{
    public class PostAlreadyExistExceptions:Exception
    {

        public PostAlreadyExistExceptions() : base(ExceptionMessage.PostAlreadyExistException)
        {


        }



    }
}
