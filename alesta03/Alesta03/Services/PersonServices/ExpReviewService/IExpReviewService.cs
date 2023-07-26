using Alesta03.Model.Request;
using Alesta03.Model.Response;

namespace Alesta03.Services.PersonServices.ExpReviewService
{
    public interface IExpReviewService
    {
        List<ExpReviews> GetAllReviews();
        ExpReviews? GetSingleReviews(int id);
        AddReviewResponse AddReview(AddReviewRequest request);
        List<ExpReviews>? UpdateReview(int id, ExpReviews request);
        List<ExpReviews>? DeleteReview(int id);

    }
}
