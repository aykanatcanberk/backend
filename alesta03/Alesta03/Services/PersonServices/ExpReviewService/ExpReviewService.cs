using Alesta03.Model;
using Alesta03.Request.AddRequest;
using Alesta03.Request.UpdateRequest;
using Alesta03.Response.AddResponse;
using Alesta03.Response.DeleteResponse;
using Alesta03.Response.GetResponse;
using Alesta03.Response.UpdateResponse;
using Microsoft.EntityFrameworkCore;

namespace Alesta03.Services.PersonServices.ExpReviewService
{
    public class ExpReviewService : IExpReviewService
    {
        private readonly DataContext _context;

        public ExpReviewService(DataContext context)
        {
            _context = context;
        }
        public async Task<AddReviewResponse> AddReview(AddReviewRequest request)
        {
            ExpReview model = new ExpReview();

            model.Title = request.Title;
            model.Description = request.Description;
            model.Date = DateTime.Now;

            _context.ExpReviews.Add(model);
            await _context.SaveChangesAsync();

            AddReviewResponse response = new AddReviewResponse();

            response.ID = model.ID;
            response.Title = model.Title;
            response.Description = model.Description;
            response.CreatedDate = model.Date;
            
            return response;
        }

        public async Task<List<ExpReview>> GetAllReviews()
        {
            var expReviews = await _context.ExpReviews.ToListAsync();
            return expReviews;
        }


        //public GetReviewResponse GetAllReviews()
        //{
        //    ExpReviews model = new ExpReviews();

        //    bool control = model.IsDeleted;

        //    if (control)
        //        return null;

        //    GetReviewResponse response = new GetReviewResponse();

        //    response.Title = model.Title;
        //    response.Date = model.Date;
        //    response.Description = model.Description;
        //    response.personId = model.PersonId;
        //    response.companyId = model.CompanyId;

        //    return response;
        //}

        public async Task<GetReviewResponse?> GetSingleReviews(int id)
        {
            var model = await _context.ExpReviews.FindAsync(id);
            bool control = model.IsDeleted;

            if (model is null)
                return null;
            if (control is true)
                return null;

            GetReviewResponse response = new GetReviewResponse();

            response.Title = model.Title;
            response.Date = model.Date;
            response.Description = model.Description;
            response.personId = (int)model.PersonId;
            response.companyId = (int)model.CompanyId;

            return response;
        }

        public async Task<UpdateReviewResponse?> UpdateReview(int id, UpdateReviewRequest request)
        {
            var model = await _context.ExpReviews.FindAsync(id);

            bool control = model.IsDeleted;

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
            
            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<DeleteReviewResponse?> DeleteReview(int id)
        {
            ExpReview model = new ExpReview();

            bool control = model.IsDeleted;

            var review = await _context.ExpReviews.FindAsync(id);

            if (review is null)
                return null;
            if (control is true)
                return null;

            model.IsDeleted = review.IsDeleted;

            model.IsDeleted = true;

            DeleteReviewResponse response = new DeleteReviewResponse();

            await _context.SaveChangesAsync();

            return response;
        }
    }
}
