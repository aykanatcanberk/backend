using Alesta03.Request.AdvetRequest;
using Alesta03.Request.PostRequest;
using Alesta03.Response.AdvertResponse;
using Alesta03.Response.PostResponse;

namespace Alesta03.Services.AdvertService
{
    public class AdvertService:IAdvertService
    {
        private readonly DataContext _context;

        public AdvertService(DataContext context)
        {
            _context = context;
        }

        public async Task<AddAdvertResponse> AddAdvert(AddAdvertRequest request)
        {
            Advert model = new Advert();
            model.CompanyName = request.CompanyName;
            model.AdvertName = request.AdvertName;
            model.AdvertDate = DateTime.Now;
            model.Description = request.Description;
            model.AdvertType = request.AdvertType;
            model.Department = request.Department;
            model.WorkType = request.WorkType;
            model.WorkPreference = request.WorkPreference;

            _context.Adverts.Add(model);
            await _context.SaveChangesAsync();

            AddAdvertResponse response = new AddAdvertResponse();
            response.UserId = model.UserId;
            response.CompanyName = model.CompanyName;
            response.AdvertName = model.AdvertName;
            response.AdvertDate = model.AdvertDate;
            response.Description = model.Description;
            response.AdvertType = model.AdvertType;
            response.Department = model.Department;
            response.WorkType = model.WorkType;
            response.WorkPreference = model.WorkPreference;
            return response;
        }

        public async Task<DeleteAdvertResponse?> DeleteAdvert(int id)
        {
            Advert model = new Advert();
            var control = model.IsDeleted;
            var review = await _context.Adverts.FindAsync(id);
            if (review is null)
                return null;
            if (control is true)
                return null;
            model.IsDeleted = review.IsDeleted;
            model.IsDeleted = true;

            DeleteAdvertResponse response = new DeleteAdvertResponse();
            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<List<GetAllAdvertResponse>> GetAllAdvert()
        {
            var adverts = await _context.Adverts.Where(advert => !advert.IsDeleted).ToListAsync();
            var responseList = adverts.Select(advert => new GetAllAdvertResponse
            {
                Id = advert.Id,
                UserId = advert.UserId,
                CompanyName = advert.CompanyName,
                AdvertName = advert.AdvertName,
                AdvertDate = advert.AdvertDate,
                Description = advert.Description,
                AdvertType = advert.AdvertType,
                Department = advert.Department,
                WorkType = advert.WorkType,
                WorkPreference = advert.WorkPreference
            }).ToList();
            return responseList;
            
        }
        public async Task<GetAdvertResponse?> GetSingleAdvert(int id)
        {
            var model = await _context.Adverts.FindAsync(id);
            var control = model.IsDeleted;

            if (model is null)
                return null;
            if (control is true)
                return null;
            GetAdvertResponse response = new GetAdvertResponse();
            response.Id = model.Id;
            response.UserId = model.UserId;
            response.CompanyName = model.CompanyName;
            response.AdvertName = model.AdvertName;
            response.AdvertDate = model.AdvertDate;
            response.Description = model.Description;
            response.AdvertType = model.AdvertType;
            response.Department = model.Department;
            response.WorkType = model.WorkType;
            response.WorkPreference = model.WorkPreference;
            return response;
        }
    }
}
