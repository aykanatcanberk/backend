using Alesta03.Model;
using Alesta03.Request.AddRequest;
using Alesta03.Request.UpdateRequest;
using Alesta03.Response.AddResponse;
using Alesta03.Services.CompanyServices.ProfileService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Alesta03.Controllers.CompanyController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICProfileService _cProfileService;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public CompanyController(ICProfileService cProfileService, DataContext context, IHttpContextAccessor contextAccessor)
        {
            _cProfileService = cProfileService;
            _context = context;
            _contextAccessor = contextAccessor;
        }

        [HttpGet, Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<List<Company>>> GetAllProfiles()
        {
            return await _cProfileService.GetAllProfiles();
        }

        [HttpGet("{id}"), Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<Company>> GetSingleProfiles(int id)
        {
            var result = await _cProfileService.GetSingleProfiles(id);
            if (result == null)
                return NotFound("Firma Bulunumadı!");

            return Ok(result);
        }

        [HttpPut("{id}"), Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<List<Company>>> UpdateProfile(int id, UpdateCProfileRequest request)
        {
            var result = await _cProfileService.UpdateProfile(id, request);
            if (result == null)
                return NotFound("Firma Bulunumadı!");

            return Ok(result);
        }

        [HttpPost, Authorize(Roles = Role.Admin)]

        public async Task<ActionResult<List<Company>>> AddProfileInfo(AddCProfileRequest request)
        {
            var userMail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == userMail);

            var id = user.ID;

            Company model = new Company();

            model.UsersId = id;
            model.Category = request.Category;
            model.Type = request.Type;
            model.Name = request.Name;
            model.Description = request.Description;
            model.FDate = request.FDate;
            model.TotalStaff = request.TotalStaff;
            model.Location = request.Location;
            model.Prof = request.Prof;
            model.Phone = request.Phone;
            model.Website = request.Website;

            _context.Companies.Add(model);
            await _context.SaveChangesAsync();

            AddCProfileResponse response = new AddCProfileResponse();

            response.Category = model.Category;
            response.Type = model.Type;
            response.Name = model.Name;
            response.Description = model.Description;
            response.FDate = model.FDate;
            response.TotalStaff = model.TotalStaff;
            response.Location = model.Location;
            response.Prof = model.Prof;
            response.Phone = model.Phone;
            response.Website = model.Website;
            response.UsersId = model.UsersId;
                        
            return Ok(response);
        }
    }
}
