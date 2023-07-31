
using Alesta03.Request.AddRequest;
using Alesta03.Request.PostRequest;
using Alesta03.Request.UpdateRequest;
using Alesta03.Response.PostResponse;
using Alesta03.Services.PersonServices.ExpReviewService;
using Alesta03.Services.PostServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alesta03.Controllers.GeneralController
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly DataContext _context;

        public PostController(DataContext context)
        {
            _context = context;
        }


        [HttpGet ,Authorize]
        public async Task<ActionResult<Post>> GetAllPosts()
        {

            var posts = await _context.Posts.Where(post => !post.IsDeleted).ToListAsync();
            var responseList = posts.Select(post => new GetAllPostResponse
            {
                Id = post.Id,
                UserId = (int)post.UserId,
                Content = post.Content,
                PostDate = post.PostDate
            }).ToList();
            return Ok(responseList);
        }

        [HttpGet("{id}") ,Authorize]
        public async Task<ActionResult<Post>> GetSinglePost(int id)
        {
            var model = await _context.Posts.FindAsync(id);
            var control = model.IsDeleted;
            if (model is null)
                return null;
            if (control is true)
                return null;
            GetPostResponse response = new GetPostResponse();
            response.Id = model.Id;
            response.UserId = (int)model.UserId;
            response.Content = model.Content;
            response.PostDate = model.PostDate;
            return Ok(response);

        }

        [HttpPost, Authorize]
        public async Task<ActionResult<List<Post>>> AddPost(AddPostRequest request)
        {
            var userMail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == userMail);
            var id = user?.ID;
            if (user == null)
                return NotFound("Kullanıcı Bulunamadı!");

            var model = _context.Posts.FirstOrDefault(x => x.UserId == id);
            if (model is not null) return NotFound("Daha Bu Post Atılmış.");

                model.UserId = id;
                model.Content = request.Content;
                model.PostDate = DateTime.Now;


                _context.Posts.Add(model);
                await _context.SaveChangesAsync();

                AddPostResponse response = new AddPostResponse();
                response.UserMail=userMail;
                response.Id=model.Id; 
                response.UserId = (int)model.UserId;
                response.Content = model.Content;

                return Ok(response);
        }

        [HttpDelete("{id}") ,Authorize]
        public async Task<ActionResult<List<Post>>> DeletePost(int id)
        {
            Post model = new Post();

            bool control = model.IsDeleted;

            var review = await _context.Posts.FindAsync(id);

            if (review is null)
                return null;
            if (control is true)
                return null;

            model.IsDeleted = review.IsDeleted;

            model.IsDeleted = true;

            DeletePostResponse response = new DeletePostResponse();

            await _context.SaveChangesAsync();

            return Ok(response);
        }
    }
}
    