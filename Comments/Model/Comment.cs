using Post_Coments_Api.Posts.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;
using Post_Coments_Api;

namespace Post_Coments_Api.Comments.Model
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name_autor")]

         public string Name_Autor { get; set; }

        [Required]
        [Column("content")]

        public string Content { get; set; }

        [Required]
        [Column("created_comment")]

        public DateTime Created_Post { get; set; }


        [Required]
        [Column("update_comment")]


        public DateTime Update_Comment { get; set; }
 

        public int Post_id { get; set; }


        public virtual Post Post { get; set; }




    }
}
