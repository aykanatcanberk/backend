using Alesta03.Model;
using Alesta03.Model.Request;
using Alesta03.Model.Response;
using Alesta03.Request.PostRequest;
using Alesta03.Response.PostResponse;
using Microsoft.EntityFrameworkCore;

namespace Alesta03.Services.PostServices
{
    public class PostService : IPostService
    {
        public AddPostResponse AddPost(AddPostRequest request)
        {
            throw new NotImplementedException();
        }

        public DeletePostResponse? DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllPost()
        {
            throw new NotImplementedException();
        }

        public GetPostResponse? GetSinglePost(int id)
        {
            throw new NotImplementedException();
        }
    }
}
