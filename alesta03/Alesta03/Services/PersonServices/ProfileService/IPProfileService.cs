using Alesta03.Request.UpdateRequest;
using Alesta03.Response.UpdateResponse;

namespace Alesta03.Services.PersonServices.ProfileService
{
    public interface IPProfileService
    {
        Task<List<Person>> GetAllPeople();
        Task<Person?> GetSinglePerson(int id);
        Task<UpdatePProfileResponse?> UpdateProfile(int id, UpdatePProfileRequest request);
    }
}
