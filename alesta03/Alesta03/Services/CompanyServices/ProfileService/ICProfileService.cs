using Alesta03.Request.UpdateRequest;
using Alesta03.Response.UpdateResponse;
using Alesta03.Response.AddResponse;
using Microsoft.AspNetCore.Mvc;
using Alesta03.Request.AddRequest;

namespace Alesta03.Services.CompanyServices.ProfileService
{
    public interface ICProfileService
    {
        Task<List<Company>> GetAllProfiles();
        Task<Company?> GetSingleProfiles(int id);
        Task<UpdateCProfileResponse?> UpdateProfile(int id, UpdateCProfileRequest request);
        Task<AddCProfileResponse> AddProfileInfo(AddCProfileRequest request);
    }
}
