using Alesta03.Model;
using Alesta03.Request.AddRequest;
using Alesta03.Request.UpdateRequest;
using Alesta03.Response.AddResponse;
using Alesta03.Response.DeleteResponse;
using Alesta03.Response.GetResponse;
using Alesta03.Response.UpdateResponse;

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
                    "falanlı filanlı bir deneyim yorumu",
                    IsDeleted=false
                },
                new ExpReviews
                {
                    ID = 2,
                    Title = "İkinci deneyim yorumum",
                    Date = DateTime.Now,
                    Description = "falanlı filanlı bir deneyim yorumu",
                    IsDeleted=false
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

        public List<ExpReviews> GetAllReviews()
        {
            return expReview;
        }

        /*
               
        public GetReviewResponse GetAllReviews()
        {
            ExpReviews model = new ExpReviews();

            bool control = model.IsDeleted;
            
            if (control is true)
                return null;
            
            GetReviewResponse response = new GetReviewResponse();

            response.Title = model.Title;
            response.Date = model.Date;
            response.Description = model.Description;
            response.personId = model.personId;
            response.companyId = model.companyId;

            return response;
        }
*/
        public GetReviewResponse? GetSingleReviews(int id)
        {
            ExpReviews model = new ExpReviews();

            bool control = model.IsDeleted;

            model = expReview.Find(x => x.ID == id);

            if (model is null)
                return null;
            if (control is true)
                return null;

            GetReviewResponse response = new GetReviewResponse();

            response.Title = model.Title;
            response.Date = model.Date;
            response.Description = model.Description;
            response.personId = model.PersonId;
            response.companyId = model.CompanyId;

            return response;
        }

        public UpdateReviewResponse? UpdateReview(int id, UpdateReviewRequest request)
        {
            ExpReviews model = new ExpReviews();

            bool control = model.IsDeleted;

            model = expReview.Find(x => x.ID == id);

            if (model is null) 
                return null;
            if (control is true)
                return null;

            model.Title = request.Title;
            model.Description = request.Description;

            UpdateReviewResponse response = new UpdateReviewResponse();

            response.Title = model.Title;
            response.UpdateDate = model.UpdateDate;
            response.Description = model.Description;

            return response;
        }

        public DeleteReviewResponse? DeleteReview(int id)
        {
            ExpReviews model = new ExpReviews();

            bool control = model.IsDeleted;
                        
            var review = expReview.Find(x => x.ID == id);

            if (review is null)
                return null;
            if (control is true)
                return null;

            model.IsDeleted = review.IsDeleted;

            model.IsDeleted = true;

            DeleteReviewResponse response = new DeleteReviewResponse();
 

            return response;
        }
    }
}
