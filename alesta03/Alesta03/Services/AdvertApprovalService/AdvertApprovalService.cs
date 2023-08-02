using Alesta03.Request.AddvertApprovalRequest;
using Alesta03.Response.AdvertApproval_Response;
using Alesta03.Response.AdvertResponse;
using Microsoft.EntityFrameworkCore;

namespace Alesta03.Services.AdvertApprovalService
{
    //public class AdvertApprovalService : IAdvertApprovalService
    //{
    //    private readonly DataContext _context;

    //    public AdvertApprovalService(DataContext context)
    //    {
    //        _context = context;
    //    }
    //    public async Task<ApplyAdvertResponse> ApplyAdvert(ApplyAdvertRequest request)
    //    {
    //        AdvertApproval model = new AdvertApproval();
    //        model.Status = "Başvuru Gerçekleştirildi.";
    //        model.ApproveDate = DateTime.Now;

    //        _context.AdvertApprovals.Add(model);
    //        await _context.SaveChangesAsync();


    //        ApplyAdvertResponse response = new ApplyAdvertResponse();
    //        response.ApprovalId = model.Id;
    //        response.PersonId = model.PersonId;
    //        response.AdvertId = model.AdvertId;
    //        response.Status = model.Status;
    //        response.ApproveDate = DateTime.Now;
    //        return response;
            
    //    }

    //    public async Task<DeleteApprovalAdvertResponse?> DeleteApproveAdvert(int id)
    //    {
    //        AdvertApproval model = new AdvertApproval();
    //        var control = model.IsDeleted;
    //        var review = await _context.Adverts.FindAsync(id);
    //        if (review is null)
    //            return null;
    //        if (control is true)
    //            return null;
    //        model.IsDeleted = review.IsDeleted;
    //        model.IsDeleted = true;
    //        model.Status = "Henüz başvuru yapılmadı.";

    //        DeleteApprovalAdvertResponse response = new DeleteApprovalAdvertResponse();
    //        await _context.SaveChangesAsync();
    //        return response;
    //    }

    //    public async Task<List<GetAdvertApprovalResponse>> GetAdvertApproval()
    //    {
    //        var approvals = await _context.AdvertApprovals.Where(approvals => !approvals.IsDeleted).ToListAsync();
    //        var responseList = approvals.Select(approval => new GetAdvertApprovalResponse
    //        {
    //            ApprovalId = approval.Id,
    //            ApproveDate =approval.ApproveDate,
    //            PersonId= approval.PersonId,
    //            AdvertId = approval.AdvertId,
    //            Status = approval.Status,
    //        }).ToList();
    //        return responseList;
    //    }
    //}
}
