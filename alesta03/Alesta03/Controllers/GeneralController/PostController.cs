using Alesta03.Request.AddRequest;
using Alesta03.Request.PostRequest;
using Alesta03.Request.UpdateRequest;
using Alesta03.Response.PostResponse;
using Alesta03.Services.PersonServices.ExpReviewService;
using Alesta03.Services.PostServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alesta03.Controllers.GeneralController
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }


        [HttpGet/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<Post>> GetAllPosts()
        {
            var result = await _postService.GetAllPosts();

            if (result == null || result.Count == 0)
                return NotFound("Gönderi bulunamadı.");
            return Ok(result);
        }

        [HttpGet("{id}")/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<Post>> GetSinglePost(int id)
        {
            var result = await _postService.GetSinglePost(id);
            if (result == null)
                return NotFound("Gönderi Bulunamadı.");

            return Ok(result);
        }

        [HttpPost/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<List<Post>>> AddPost(AddPostRequest request)
        {
            var result = await _postService.AddPost(request);
            return Ok(result);
        }


        [HttpDelete("{id}")/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<List<Post>>> DeletePost(int id)
        {
            var result = await _postService.DeletePost(id);
            if (result == null)
                return NotFound("Gönderi bulunamadı.");

            return Ok(result);
        }
    }
}
