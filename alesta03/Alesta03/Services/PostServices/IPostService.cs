using Alesta03.Model.Request;
using Alesta03.Model.Response;
using Alesta03.Request.PostRequest;
using Alesta03.Response.PostResponse;

namespace Alesta03.Services.PostServices
{
    public interface IPostService
    {
        List<Post> GetAllPost();
        GetPostResponse? GetSinglePost(int id);
        AddPostResponse AddPost(AddPostRequest request);
        DeletePostResponse? DeletePost(int id);
    }
}