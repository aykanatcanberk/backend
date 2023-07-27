using Alesta03.Request.UpdateRequest;
using Alesta03.Response.UpdateResponse;

namespace Alesta03.Services.CompanyServices.ProfileService
{
    public interface ICProfileService
    {
        List<Company> GetAllProfiles();
        Company? GetSingleProfiles(int id);
        UpdateCProfileResponse? UpdateProfile(int id, UpdateCProfileRequest request);
    }
}
