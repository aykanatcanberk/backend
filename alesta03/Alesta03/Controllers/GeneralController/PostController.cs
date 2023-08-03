using Alesta03.Model;
using Alesta03.Request.AddRequest;
using Alesta03.Request.PostRequest;
using Alesta03.Request.UpdateRequest;
using Alesta03.Response.AdvertApproval_Response;
using Alesta03.Response.PostResponse;
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

        [HttpGet("AllPosts"), Authorize]
        public async Task<ActionResult<Post>> GetAllPosts()
        {
            var mail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == mail);
            var id = user?.ID;
            if (user == null)
                return NotFound("Gönderi Bulunamadı!");

            var Posts = await _context.Posts.ToListAsync();
            var responseList = new List<GetPostResponse>();

            foreach (var post in Posts)
            {
                var postid = post.UserId;
                var person = _context.People.FirstOrDefault(y => y.UsersId == postid);
                var name = person.Name;

                var _post = await _context.Posts
                    .Where(aa => aa.UserId == postid)
                    .Select(aa => new GetPostResponse
                    {
                        Name = name,
                        Content = aa.Content,
                        PostDate = aa.PostDate,
                    }).ToListAsync();

                responseList.AddRange(_post);
            }

            return Ok(responseList);
        }

        [HttpGet("PersonPosts"), Authorize]
        public async Task<ActionResult<Post>> GetPersonPosts()
        {
            var mail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == mail);
            var id = user?.ID;
            if (user == null)
                return NotFound("Gönderi Bulunamadı!");

            var model = _context.Posts.FirstOrDefault(x => x.UserId == id);
            if (model == null)
                return NotFound("Gönderi Bilgisi Bulunamadı!");
            var person = _context.People.FirstOrDefault(y => y.UsersId == id);

            var name = person.Name;

            var _post = await _context.Posts
                .Where(aa => aa.UserId == id)
                .Select(aa => new GetPostResponse
                {
                    Name = name,
                    Content = aa.Content,
                    PostDate = aa.PostDate,
                }).ToListAsync();
            return Ok(_post);
        }

        [HttpPost, Authorize]
        public async Task<ActionResult<List<Post>>> AddPost(AddPostRequest request)
        {
            var userMail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == userMail);
            var id = user?.ID;
            if (user == null)
                return NotFound("Kullanıcı Bulunamadı!");
            var newPost = new Post
            {
                UserId = id,
                Content = request.Content,
                PostDate = DateTime.Now
            };

            _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();



            AddPostResponse response = new AddPostResponse();
            response.Id = newPost.Id;
            response.UserId = newPost.UserId;
            response.PostDate = newPost.PostDate;
            response.Content = newPost.Content;

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
