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
        [Route("api/[controller]/personpage")]

        [HttpGet,Authorize]
        public async Task<ActionResult<Advert>> GetAllAdvertPerson()
        {
            var adverts = await _context.Adverts.Where(advert => !advert.IsDeleted).ToListAsync();
            var responseList = adverts.Select(advert => new GetAllAdvertPersonResponse
            {
                CompanyName = advert.CompanyName,
                AdvertName = advert.AdvertName,
                AdvertDate = advert.AdvertDate,
                Description = advert.Description,
                AdvertType = advert.AdvertType,
            }).ToList();
            return Ok(responseList);

        }

        [Route("api/[controller]/companypage")]
        [HttpGet, Authorize]
        public async Task<ActionResult<Advert>> GetAllAdvertCompany()
        {
            var userName = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(x => x.Email == userName);
            var userId = user?.ID;

            if (userId == null)
                return Unauthorized();

            var adverts = await _context.Adverts
                .Where(advert => advert.UserId == userId && !advert.IsDeleted)
                .Select(advert => new GetAllAdvertCompanyResponse
                {
                    AdvertName = advert.AdvertName,
                    AdvertDate = advert.AdvertDate,
                    Description = advert.Description,
                    AdvertType = advert.AdvertType,
                })
                .ToListAsync();
            return Ok(adverts);
        }

        [HttpGet("{idd}"), Authorize]
        public async Task<ActionResult<Advert>> GetSingleAdvert(int idd)
        {
            var userMail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(x => x.Email == userMail);
            var id = user?.ID;

            var AdvertId = idd;
            var model = await _context.Adverts.FindAsync(AdvertId);
            var control = model.IsDeleted;
            if (model is null)
                return null;
            if (control is true)
                return null;

            GetAdvertResponse response = new GetAdvertResponse();
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
            var user = _context.Users.FirstOrDefault(x => x.Email == userMail);
            var id = user?.ID;

            if (user == null)
                return NotFound("Kullanıcı Bulunamadı!");

            var company = _context.Companies.FirstOrDefault(u => u.ID == id);

            var newAdvert = new Advert
            {
                UserId = id,
                CompanyName = "Aselsan",
                AdvertName = request.AdvertName,
                AdvertDate = DateTime.Now,
                Description = request.Description,
                AdvertType = request.AdvertType,
                Department = request.Department,
                WorkType = request.WorkType,
                WorkPreference = request.WorkPreference
            };

        }
}
