using Alesta03.Request.AddRequest;
using Alesta03.Request.PostRequest;
using Alesta03.Request.UpdateRequest;
using Alesta03.Response.AddResponse;
using Alesta03.Response.DeleteResponse;
using Alesta03.Response.GetResponse;
using Alesta03.Response.PostResponse;
using Alesta03.Response.UpdateResponse;

namespace Alesta03.Services.PostServices
{
    public interface IPostService
    {
        //GetAllPostResponse GetAllPost();
        //GetPostResponse? GetSinglePost(int id);
        //AddPostResponse AddPost(AddPostRequest request);
        //DeletePostResponse? DeletePost(int id);
        Task<List<GetAllPostResponse>> GetAllPosts();
        Task<GetPostResponse?> GetSinglePost(int id);
        Task<AddPostResponse> AddPost(AddPostRequest request);
        Task<DeletePostResponse?> DeletePost(int id);
    }
}


