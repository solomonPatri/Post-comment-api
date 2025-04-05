using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Post_Coments_Api.Posts.Dtos
{
    public class PostRequest
    {


        [Required]

        public string Title { get; set; }


        [Required]
     

        public string Content { get; set; }


        [Required]
        

        public DateTime Created_Post { get; set; }


        [Required]
       

        public DateTime Update_Post { get; set; }



















    }
}
