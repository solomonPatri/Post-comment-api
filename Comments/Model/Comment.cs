using Post_Coments_Api.Posts.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;
using Post_Coments_Api;

namespace Post_Coments_Api.Comments.Model
{
    [Table("comments")]
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
        [Column("Content")]

        public string Content { get; set; }

        [Required]
        [Column("Created")]

        public DateTime Created { get; set; }

        public int PostId { get; set; }


        public virtual Post Post { get; set; }




    }
}
