using Alesta03.Request.AdvetRequest;
using Alesta03.Request.PostRequest;
using Alesta03.Response.AdvertResponse;
using Alesta03.Response.PostResponse;

namespace Alesta03.Services.AdvertService
{
    public interface IAdvertService
    {
        Task<List<GetAllAdvertResponse>> GetAllAdvert();
        Task<GetAdvertResponse?> GetSingleAdvert(int id);
        Task<AddAdvertResponse> AddAdvert(AddAdvertRequest request);
        Task<DeleteAdvertResponse?> DeleteAdvert(int id);
    }
}
