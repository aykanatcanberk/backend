using Alesta03.Request.AdvetRequest;
using Alesta03.Request.PostRequest;
using Alesta03.Response.AdvertResponse;
using Alesta03.Response.PostResponse;
using Alesta03.Services.AdvertService;
using Alesta03.Services.PostServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alesta03.Controllers.GeneralController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly DataContext _context;

        public AdvertController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Advert>> GetAllAdvert()
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
            return Ok(responseList);

        }

        [HttpGet("{id}"),Authorize]
        public async Task<ActionResult<Advert>> GetSingleAdvert(int id)
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
            return Ok(response);
        }

        [HttpPost, Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<List<Advert>>> AddAdvert(AddAdvertRequest request)
        {
            var userMail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == userMail);
            var id = user?.ID;
            if (user == null)
                return NotFound("Kullanıcı Bulunumadı!");

            var model = _context.Adverts.FirstOrDefault(x => x.UserId == id);
            if (model is not null) return NotFound("Daha Bu Post Atılmış.");

            model.UserId = id;
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

            return Ok(response);
        }


        [HttpDelete("{id}")/*, Authorize(Roles = Role.Admin)*/]
        public async Task<ActionResult<List<Advert>>> DeleteAdvert(int id)
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
            return Ok(response);
        }
    }
}
