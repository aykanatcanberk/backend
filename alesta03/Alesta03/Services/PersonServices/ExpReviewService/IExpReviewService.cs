using Alesta03.Request.AddRequest;
using Alesta03.Request.UpdateRequest;
using Alesta03.Response.AddResponse;
using Alesta03.Response.DeleteResponse;
using Alesta03.Response.GetResponse;
using Alesta03.Response.UpdateResponse;
using Microsoft.AspNetCore.Mvc;

namespace Alesta03.Services.PersonServices.ExpReviewService
{
    public interface IExpReviewService
    {
        //GetReviewResponse GetAllReviews();
        Task<List<ExpReview>> GetAllReviews();
        Task<GetReviewResponse?> GetSingleReviews(int id);
        Task<AddReviewResponse> AddReview(AddReviewRequest request);
        Task<UpdateReviewResponse?> UpdateReview(int id, UpdateReviewRequest request);
        Task<DeleteReviewResponse?> DeleteReview(int id);
    }
}

