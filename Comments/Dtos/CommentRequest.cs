using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Post_Coments_Api.Posts.Model;

namespace Post_Coments_Api.Comments.Dtos
{
    public class CommentRequest
    {

        public string Name_Autor { get; set; }

        public string Content { get; set; }
        public int PostId { get; set; }









    }
}
