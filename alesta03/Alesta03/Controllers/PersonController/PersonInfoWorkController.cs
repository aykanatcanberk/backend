using Alesta03.Request.UpdateRequest;
using Alesta03.Services.PersonServices.InfoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alesta03.Controllers.PersonController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonInfoWorkController : ControllerBase
    {
        private readonly IPersonInfoWorkService _personInfoworkService;

        public PersonInfoWorkController(IPersonInfoWorkService personworkInfoService)
        {
            _personInfoworkService = personworkInfoService;
        }
        
        [HttpGet/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<List<BackWork>>> GetAllWorks()
        {
            var result = _personInfoworkService.GetAllWorks();
            return Ok(result);
        }

        [HttpGet("{id}")/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<BackWork>> GetSingleWork(int id)
        {
            var result = _personInfoworkService.GetSingleWork(id);
            if (result == null)
                return NotFound("İş Geçmişi Bulunumadı!");

            return Ok(result);
        }

        [HttpPut("{id}")/*, Authorize(Roles = Roles.User)*/]
        public async Task<ActionResult<List<BackWork>>> UpdateWorkInfo(int id, UpdateInfoWorkRequest request)
        {
            var result = _personInfoworkService.UpdateWorkInfo(id, request);
            if (result == null)
                return NotFound("İş Geçmişi Bulunumadı!");

            return Ok(result);
        }

    }
}
