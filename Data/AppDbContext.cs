using Post_Coments_Api.Posts.Model;
using Post_Coments_Api.Comments.Model;
using Post_Coments_Api;
using Microsoft.EntityFrameworkCore;

namespace Post_Coments_Api.Data
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {



        }

        public virtual DbSet<Post> Posts
        {
            get;set;
        }

        public virtual DbSet<Comment> Comments
        {
            get;set;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
                .HasMany(s => s.Comments)
                .WithOne(b => b.Post)
                .HasForeignKey(b => b.PostId)
                .OnDelete(DeleteBehavior.Cascade); 





        }



















    }
}
