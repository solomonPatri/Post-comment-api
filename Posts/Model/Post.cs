using Post_Coments_Api.Comments.Model;
using Post_Coments_Api;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Post_Coments_Api.Posts.Model
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]

        public int Id { get; set;}

        [Required]
        [Column("title")]

        public string Title { get; set; }


        [Required]
        [Column("content")]


        public string Content { get; set; }


        [Required]
        [Column("created_post")]

        public DateTime Created_Post { get; set; }


        [Required]
        [Column("update_post")]

        public DateTime Update_Post { get; set; }

        public virtual List<Comment> Comments { get; set; } = new();

        










    }
}
