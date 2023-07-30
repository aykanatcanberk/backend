
using Alesta03.Model;
using Alesta03.Request.AddRequest;
using Alesta03.Request.PostRequest;
using Alesta03.Request.UpdateRequest;
using Alesta03.Response.AddResponse;
using Alesta03.Response.DeleteResponse;
using Alesta03.Response.GetResponse;
using Alesta03.Response.PostResponse;
using Alesta03.Response.UpdateResponse;
using Alesta03.Services.PostServices;
using Microsoft.Extensions.Hosting;

namespace Alesta03.Services.PostServices
{
    public class PostService : IPostService
    {
        private readonly DataContext _context;

        public PostService(DataContext context)
        {
            _context = context;
        }
        public async Task<AddPostResponse> AddPost(AddPostRequest request)
        {
            Post model = new Post();

            model.Content = request.Content;
            model.PostDate = DateTime.Now;


            _context.Posts.Add(model);
            await _context.SaveChangesAsync();

            AddPostResponse response = new AddPostResponse();
            response.Id=model.Id; 
            response.UserId = model.UserId;
            response.PostDate =model.PostDate;
            response.Content = model.Content;
            return response;
        }

        public async Task<List<GetAllPostResponse>> GetAllPosts()
        {

            var posts = await _context.Posts.Where(post => !post.IsDeleted).ToListAsync();
            var responseList = posts.Select(post => new GetAllPostResponse
            {
                Id = post.Id,
                UserId = post.UserId,
                Content = post.Content,
                PostDate = post.PostDate
            }).ToList();
            return responseList;
        }

        public async Task<DeletePostResponse?> DeletePost(int id)
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

            return response;
        }

        public async Task<GetPostResponse?> GetSinglePost(int id)
        {
            var model = await _context.Posts.FindAsync(id);
            var control = model.IsDeleted;

            if (model is null)
                return null;
            if (control is true)
                return null;
            GetPostResponse response = new GetPostResponse();
            response.Id = model.Id;
            response.UserId = model.UserId;
            response.Content = model.Content;
            response.PostDate = model.PostDate;
            return response;
        }
    }
}
