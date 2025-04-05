using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Post_Coments_Api.Comments.Dtos
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public string Name_Autor { get; set; }

        public DateTime Created { get; set; }

        public int Post_id { get; set; }











    }
}
