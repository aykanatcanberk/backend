using Alesta03.Request.UpdateRequest;
using Alesta03.Services.PersonServices.InfoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alesta03.Controllers.PersonController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonInfoEduController : ControllerBase
    {
        private readonly IPersonInfoEduService _personInfoEduService;

        public PersonInfoEduController(IPersonInfoEduService personInfoEduService)
        {
            _personInfoEduService = personInfoEduService;
        }

        [HttpGet/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<List<BackEdu>>> GetAllEdu()
        {
            var result = await _personInfoEduService.GetAllEdu();
            return Ok(result);
        }

        [HttpGet("{id}")/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<BackEdu>> GetSingleEdu(int id)
        {
            var result = await _personInfoEduService.GetSingleEdu(id);
            if (result == null)
                return NotFound("Eğitim Geçmişi Bulunumadı!");

            return Ok(result);
        }

        [HttpPut("{id}")/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<List<BackEdu>>> UpdateEduInfo(int id, UpdateInfoEduRequest request)
        {
            var result = await _personInfoEduService.UpdateEduInfo(id, request);
            if (result == null)
                return NotFound("Eğitim Geçmişi Bulunumadı!");

            return Ok(result);
        }
    }
}
