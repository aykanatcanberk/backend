using Alesta03.Model;
using Alesta03.Request.UpdateRequest;
using Alesta03.Services.CompanyServices.InfoService;
using Alesta03.Services.CompanyServices.ProfileService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alesta03.Controllers.CompanyController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICProfileService _cProfileService;

        public CompanyController(ICProfileService cProfileService)
        {
            _cProfileService = cProfileService;
        }
        [HttpGet/*, Authorize(Roles = Roles.Admin)*/]
        public async Task<ActionResult<List<Company>>> GetAllProfiles()
        {
            var result = _cProfileService.GetAllProfiles();
            return Ok(result);
        }

        [HttpGet("{id}")/*, Authorize(Roles = Roles.Admin)*/]
        public async Task<ActionResult<Company>> GetSingleProfiles(int id)
        {
            var result = _cProfileService.GetSingleProfiles(id);
            if (result == null)
                return NotFound("Firma Bulunumadı!");

            return Ok(result);
        }

        [HttpPut("{id}")/*, Authorize(Roles = Roles.Admin)*/]
        public async Task<ActionResult<List<Company>>> UpdateProfile(int id, UpdateCProfileRequest request)
        {
            var result = _cProfileService.UpdateProfile(id, request);
            if (result == null)
                return NotFound("Firma Bulunumadı!");

            return Ok(result);
        }
    }
}
