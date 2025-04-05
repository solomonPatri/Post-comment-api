using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Post_Coments_Api.Comments.Model;

namespace Post_Coments_Api.Posts.Dtos
{
    public class PostResponse
    {
        public int Id { get; set; }    


        public string Title { get; set; }



        public string Content { get; set; }


        public DateTime Created_Post { get; set; }

        public DateTime Update_Post { get; set; }


        public virtual List<Comment> Comments { get; set; } = new();











    }
}
