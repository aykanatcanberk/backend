
using Alesta03.Model;
using Alesta03.Request.AddRequest;
using Alesta03.Request.PostRequest;
using Alesta03.Request.UpdateRequest;
using Alesta03.Response.AdvertApproval_Response;
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

        [HttpGet("AllPosts"),Authorize]
        public async Task<ActionResult<Post>> GetAllPosts()
        {
            var mail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == mail);
            var id = user?.ID;
            if (user == null)
                return NotFound("Gönderi Bulunamadı!");

            var posts = await _context.Posts.Where(post => !post.IsDeleted).ToListAsync();
            var responseList = posts.Select(post => new GetAllPostResponse
            {   
                Name = _context.People.FirstOrDefault(x => x.UsersId == id).Name,
                Content = post.Content,
                PostDate = post.PostDate,
            }).ToList();
            return Ok(responseList);
        }

        [HttpGet("PersonPosts"), Authorize]
        public async Task<ActionResult<Post>> GetSinglePost()
        {
            var mail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == mail);
            var id = user?.ID;
            if (user == null)
                return NotFound("Gönderi Bulunamadı!");

            var model = _context.Posts.FirstOrDefault(x => x.UserId == id);
            if (model == null) 
                return NotFound("Gönderi Bilgisi Bulunamadı!");
           var name= _context.People.FirstOrDefault(x => x.UsersId == id).Name;
            var _post = await _context.Posts
                .Where(aa => aa.UserId == id)
                .Select(aa => new GetPostRequest
                {   Name=name,
                    Content = aa.Content,
                    PostDate = aa.PostDate,
                }).ToListAsync();
            return Ok(_post);
        }

        [HttpPost, Authorize]
        public async Task<ActionResult<List<Post>>>AddPost(AddPostRequest request)
        {
            var userName = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == userName);
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


            var name = _context.People.FirstOrDefault(x => x.UsersId == id).Name;

            AddPostResponse response = new AddPostResponse();
                response.UserName= name;
                response.PostDate = model.PostDate;
                response.Content = model.Content;

                return Ok(response);
        }

        [HttpDelete, Authorize]
        public async Task<ActionResult<List<Post>>> DeletePost()
        {
            
            var userName = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == userName);
            var userId = user?.ID;

            if (userId == null)
            {
                return Unauthorized();
            }
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.UserId == userId && !p.IsDeleted);
           
            if (post == null)
            {
                return NotFound("Gönderi Bulunamadı.");
            }
            post.IsDeleted = true;
            await _context.SaveChangesAsync();

            DeletePostResponse response = new DeletePostResponse();
            return Ok(response);
        }
    }
}
    