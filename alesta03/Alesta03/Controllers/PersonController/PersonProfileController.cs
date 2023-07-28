using Alesta03.Request.UpdateRequest;
using Alesta03.Services.PersonServices.ProfileService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alesta03.Controllers.PersonController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonProfileController : ControllerBase
    {
        private readonly IPProfileService _profileService;

        public PersonProfileController(IPProfileService profileService)
        {
            _profileService = profileService;
        }
        [HttpGet/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<List<Person>>> GetAllPeople()
        {
            var result = _profileService.GetAllPeople();
            return Ok(result);
        }

        [HttpGet("{id}")/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<Person>> GetSinglePerson(int id)
        {
            var result = _profileService.GetSinglePerson(id);
            if (result == null)
                return NotFound("Kullanıcı Bulunumadı!");

            return Ok(result);
        }

        [HttpPut("{id}")/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<List<Person>>> UpdateProfile(int id, UpdatePProfileRequest request)
        {
            var result = _profileService.UpdateProfile(id, request);
            if (result == null)
                return NotFound("Kullanıcı Bulunumadı!");

            return Ok(result);
        }
    }
}
