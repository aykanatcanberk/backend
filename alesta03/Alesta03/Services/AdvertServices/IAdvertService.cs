using Alesta03.Model.Request;
using Alesta03.Model.Response;
using Alesta03.Request;
using Alesta03.Request.AdvertRequest;
using Alesta03.Response;
using Alesta03.Response.AdvertResponse;

namespace Alesta03.Services.AdvertServices
{
    public interface IAdvertService
    {
        List<Advert>GetAllAdverts();
        GetAdvertResponse? GetSingleAdvert(int id);
        AddAdvertResponse AddAdvert(AddAdvertRequest request);
        UpdateAdvertResponse? UpdateAdvert(int id, UpdateAdvertRequest request);
        DeleteAdvertResponse? DeleteAdvert(int id);     
    }
}
