using Microsoft.AspNetCore.Mvc;
using Post_Coments_Api.Comments.Dtos;
using Post_Coments_Api.Comments.Exceptions;
using Post_Coments_Api.Posts.Dtos;
using Post_Coments_Api.Posts.Exceptions;
using Post_Coments_Api.Posts.Services;

namespace Post_Coments_Api.Posts
{
    [ApiController]
    [Route("api/v1/[Controller]")]

    public class PostController:ControllerBase
    {

        private readonly ICommandServicePost _command;
        private IQueryServicePost _query;

        public PostController(ICommandServicePost command,IQueryServicePost query)
        {
            _query = query;
            _command = command;
        }

        [HttpGet("AllPosts")]

        public async Task<ActionResult<GetAllPostsDtos>> GetAllPostAsync()
        {

            try
            {
                GetAllPostsDtos response = await _query.GetAllPosts();

                return Ok(response);


            }catch(PostNotFoundException nf)
            {
                return NotFound(nf.Message);

            }

        }

        [HttpPost("create")]

        public async Task<ActionResult<PostResponse>> CreatePostAsync([FromBody]PostRequest request)
        {
            try
            {
                PostResponse response = await _command.CreatePostAsyc(request);

                return Created("", response);

            }catch(PostAlreadyExistExceptions al)
            {
                return BadRequest(al.Message);
            }






        }

        [HttpPost("addComment")]

        public async Task<ActionResult<CommentResponse>> AddCommentAsync([FromBody]CommentRequest comment)
        {
            try
            {
                var response = await _command.AddCommentAsync(comment);

                return Created("", response);

            }catch(PostNotFoundException nf)
            {
                return NotFound(nf.Message);
            }


        }


        [HttpPut("updatePost/{id}")]

        public  async Task<ActionResult<PostResponse>> UpdatePostAsync([FromRoute]int id, [FromBody]PostUpdateRequest update)
        {
            try
            {
                PostResponse response = await _command.UpdatePostsAsync(id, update);
                return Accepted("", response);

            }catch(PostNotFoundException nf)
            {
                return NotFound(nf.Message);
            }





        }

        [HttpDelete("DeletePost/{id}")]

        public async Task<ActionResult<PostResponse>> DeletePostAsync([FromRoute] int id)
        {
            try
            {
                PostResponse response = await _command.DeletePostAsync(id);

                return Accepted("", response);
            }catch(PostNotFoundException nf)
            {
                return NotFound(nf.Message);
            }


        }

        [HttpDelete("DeleteCommentToPost/{idpost}/{idcomment}")]

        public async Task<ActionResult<CommentResponse>> DeleteCommentAsync([FromRoute]int idpost, [FromRoute]int idcomment)
        {

            try
            {
                CommentResponse response = await _command.DeleteCommentAsync(idpost, idcomment);

                return Accepted("", response);


            }catch(CommentNotFoundException nf)
            {
                return NotFound(nf.Message);

            }catch(PostNotFoundException nf)
            {
                return NotFound(nf.Message);
            }





        }






    }
}
