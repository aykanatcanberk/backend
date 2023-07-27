using Alesta03.Request.UpdateRequest;
using Alesta03.Response.UpdateResponse;

namespace Alesta03.Services.PersonServices.ProfileService
{
    public interface IPProfileService
    {
        List<Person> GetAllPeople();
        Person? GetSinglePerson(int id);
        UpdatePProfileResponse? UpdateProfile(int id, UpdatePProfileRequest request);
    }
}
