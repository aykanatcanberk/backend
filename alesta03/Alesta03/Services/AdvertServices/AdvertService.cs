using Alesta03.Model;
using Alesta03.Model.Request;
using Alesta03.Model.Response;
using Alesta03.Request.AdvertRequest;
using Alesta03.Response.AdvertResponse;

namespace Alesta03.Services.AdvertServices
{
    public class AdvertService : IAdvertService
    {

        public static List<Advert> adverts = new List<Advert>
            {
                new Advert { Id = 1, UserId = 1, AdvertName = "Staj", CompanyName = "Alesta", AdvertDate = DateTime.Now },
                new Advert { Id = 2, UserId = 1, AdvertName = "Staj", CompanyName = "Alesta", AdvertDate = DateTime.Now }
            };
       
        private readonly DataContext _context;
        public AdvertService(DataContext context)
        {
            _context = context;
        }
  

        public List<Advert> GetAllAdverts()
        {
            
            return adverts;
        }
     
        public GetAdvertResponse? GetSingleAdvert(int id)
        {
            Advert model = new Advert();

            var control = model.IsDeleted;

            model = adverts.Find(x => x.Id == id);

            if (model is null)
                return null;
            if (control is true)
                return null;

            GetAdvertResponse response = new GetAdvertResponse();

            response.CompanyName = model.CompanyName;
            response.AdvertName= model.AdvertName;
            response.AdvertDate = model.AdvertDate;
            response.Description = model.Description;
            response.AdvertType=model.AdvertType;
            response.Department=model.Department;
            response.WorkType = model.WorkType;
            response.WorkPreference = model.WorkPreference;

            return response;
        }

        public AddAdvertResponse AddAdvert(AddAdvertRequest request)
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

            AddAdvertResponse response = new AddAdvertResponse();
            response.Id=model.Id;
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

        public UpdateAdvertResponse? UpdateAdvert(int id, UpdateAdvertRequest request)
        {
            Advert model = new Advert();
            var control = model.IsDeleted;
            if (control == true || model == null)
                return null;
            model.CompanyName = request.CompanyName;
            model.AdvertName = request.AdvertName;
            model.AdvertDate = DateTime.Now;
            model.Description = request.Description;
            model.AdvertType = request.AdvertType;
            model.Department = request.Department;
            model.WorkType = request.WorkType;
            model.WorkPreference = request.WorkPreference;

            UpdateAdvertResponse response=new UpdateAdvertResponse();
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

        DeleteAdvertResponse? IAdvertService.DeleteAdvert(int id)
        {

            Advert model = new Advert();
            var control = model.IsDeleted;
            var review = adverts.Find(x => x.Id == id);
            if (review == null || control == true)
                return null;
            model.IsDeleted = review.IsDeleted;
            model.IsDeleted = true;
            DeleteAdvertResponse response = new DeleteAdvertResponse();
            return response;
        }
    }
}
