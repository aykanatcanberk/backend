using Alesta03.Model;
using Alesta03.Model.Request;
using Alesta03.Model.Response;
using Alesta03.Request;
using Alesta03.Response;

namespace Alesta03.Services.PersonServices.ExpReviewService
{
    public class ExpReviewService : IExpReviewService
    {
        private static List<ExpReviews> expReview = new List<ExpReviews>
            {
                new ExpReviews
                {
                    ID = 1,
                    Title = "İlk deneyim yorumum",
                    Date = DateTime.Now,
                    Description =
                    "falanlı filanlı bir deneyim yorumu"
                },
                new ExpReviews
                {
                    ID = 2,
                    Title = "İkinci deneyim yorumum",
                    Date = DateTime.Now,
                    Description = "falanlı filanlı bir deneyim yorumu"
                }
        };
        public AddReviewResponse AddReview(AddReviewRequest request)
        {
            ExpReviews model = new ExpReviews();
            model.Title = request.Title;
            model.Description = request.Description;
            model.Date = DateTime.Now;

            expReview.Add(model);

            AddReviewResponse response = new AddReviewResponse();
            response.ID = model.ID;
            response.Title = model.Title;
            response.Description = model.Description;
            response.CreatedDate = model.Date;


            return response;
        }

        public List<ExpReviews>? DeleteReview(int id)
        {
            var review = expReview.Find(x => x.ID == id);
            if (review is null) 
                return null;

            review.IsDeleted = true;

            return expReview;
        }

        public List<ExpReviews> GetAllReviews()
        {
            return expReview;
        }

        public ExpReviews? GetSingleReviews(int id)
        {
            var review = expReview.Find(x => x.ID == id);
            if (review is null)
                return null;
            return review;
        }

        public List<ExpReviews>? UpdateReview(int id, ExpReviews request)
        {
            var review = expReview.Find(x => x.ID == id);
            if (review is null) 
                return null;

            review.Title = request.Title;
            review.Description = request.Description;

            return expReview;
        }
    }
}
