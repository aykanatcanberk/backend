using Alesta03.Request.AddvertApprovalRequest;
using Alesta03.Request.AdvetRequest;
using Alesta03.Response.AdvertApproval_Response;
using Alesta03.Response.AdvertResponse;

namespace Alesta03.Services.AdvertApprovalService
{
    public interface IAdvertApprovalService
    {
        Task<ApplyAdvertResponse> ApplyAdvert(ApplyAdvertRequest request);
        Task<List<GetAdvertApprovalResponse>> GetAdvertApproval();
        Task<DeleteApprovalAdvertResponse?> DeleteApproveAdvert(int id);


    }
}
