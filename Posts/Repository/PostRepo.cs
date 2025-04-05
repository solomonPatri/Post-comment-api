using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Post_Coments_Api.Comments.Dtos;
using Post_Coments_Api.Comments.Model;
using Post_Coments_Api.Data;
using Post_Coments_Api.Posts.Dtos;
using Post_Coments_Api.Posts.Model;
namespace Post_Coments_Api.Posts.Repository
{
    public class PostRepo:IPostRepo
    {

        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public PostRepo(AppDbContext context,IMapper mapper)
        {

            _context = context;
            _mapper = mapper;



        }


        public async Task<GetAllPostsDtos> GetAllPostsAsync()
        {
            var posts = await _context.Posts.Include(s => s.Comments).ToListAsync();

            var mapped = _mapper.Map<List<PostResponse>>(posts);
            return new GetAllPostsDtos
            {
                ListPosts = mapped


        };




        }

        public async Task<PostResponse> CreatePostAsyc(PostRequest create)
        {

            var postsentity = _mapper.Map<Post>(create);
            await _context.Posts.AddAsync(postsentity);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<PostResponse>(postsentity);
            return response;





        }

        public async Task<PostResponse> GetByIdAsync(int id)
        {
            var post = await _context.Posts.Include(s => s.Comments)
                .FirstOrDefaultAsync(s => s.Id == id);
            return _mapper.Map<PostResponse>(post);



        }

        public async Task<Post?> GetEntityByIdAsync(int id)
        {
            return await _context.Posts.
                Include(s => s.Comments)
                .FirstOrDefaultAsync(b => b.Id == id);





        }

        public async Task<PostResponse> UpdateAsync(int id, PostUpdateRequest update)
        {
            Post exist = await _context.Posts.FindAsync(id);

            if (update.Title != null)
            {
                exist.Title = update.Title;
            }
            if (update.Content != null)
            {
                exist.Content = update.Content;
            }
            if (update.Created_Post.HasValue)
            {
                exist.Created_Post = update.Created_Post.Value;
            }
            if (update.Update_Post.HasValue)
            {
                exist.Update_Post = update.Update_Post.Value;
            }
            _context.Update(exist);
            await _context.SaveChangesAsync();

            PostResponse response = _mapper.Map<PostResponse>(exist);

            return response;







        }

        public async Task<PostResponse> FindByNamePostAsync(string name)
        {
            Post searched = await _context.Posts.FirstOrDefaultAsync(s => s.Title.Equals(name));

            PostResponse response = _mapper.Map<PostResponse>(searched);

            return response;





        }


        public async Task<PostResponse> FindByIdAsync(int id)
        {
            Post post = await _context.Posts.FindAsync(id);

            PostResponse response = _mapper.Map<PostResponse>(post);

            return response;




        }

        public async Task UpdateAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();


        }

        public async Task<PostResponse> DeletePostAsync(int id)
        {
            Post post = await _context.Posts.FindAsync(id);

            PostResponse response = _mapper.Map<PostResponse>(post);

            await _context.SaveChangesAsync();

            return response;



        }


        public async Task<CommentResponse> DeleteCommentAsync(int idpost, int idcomment)
        {

            Post post = await GetEntityByIdAsync(idpost);

            Comment comment = post.Comments.FirstOrDefault(s => s.Id == idcomment);

            if (post != null)
            {

                post.Comments.Remove(comment);
               

            }
            await _context.SaveChangesAsync();
            return _mapper.Map<CommentResponse>(comment);




        }













    }
}
