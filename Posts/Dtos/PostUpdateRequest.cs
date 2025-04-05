using System.ComponentModel.DataAnnotations;

namespace Post_Coments_Api.Posts.Dtos
{
    public class PostUpdateRequest
    {

        public string ?Title { get; set; }



        public string? Content { get; set; }


        

        public DateTime? Created_Post { get; set; }



        public DateTime ?Update_Post { get; set; }



















    }
}
