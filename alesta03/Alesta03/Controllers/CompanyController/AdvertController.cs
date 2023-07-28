using Alesta03.Model;
using Alesta03.Request.AdvertRequest;
using Alesta03.Services.AdvertServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Alesta03.Controllers.CompanyController
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertService _advertService;
        public AdvertController(IAdvertService advertService)
        {
            _advertService=advertService;
        }

        [HttpGet/*, Authorize(Roles = Roles.Admin)*/]
        public async Task<ActionResult<List<Advert>>>GetAllAdverts()
        {

            return _advertService.GetAllAdverts();
        }
        [HttpGet("{id}")/*, Authorize(Roles = Roles.Admin)*/]
        public async Task<ActionResult<Advert>> GetSingleAdvert(int id)
        {

            var result = _advertService.GetSingleAdvert( id);
            if (result == null)
                return NotFound("İlan bulunamadı.");
            return Ok(result);
        }

        [HttpPost/*, Authorize(Roles = Roles.Admin)*/]
        public async Task<ActionResult<List<Advert>>> AddAdvert(AddAdvertRequest request)
        {
            var result=_advertService.AddAdvert(request );
            return Ok(result);
        }

        [HttpPut/*, Authorize(Roles = Roles.Admin)*/]
        public async Task<ActionResult<Advert>> UpdateAdvert(UpdateAdvertRequest request, int id)
        {
           var result=_advertService.UpdateAdvert(id,request);
            if (result == null)
                return NotFound("İlan bulunamadı.");
            return Ok(result);
        }

        [HttpDelete/*, Authorize(Roles = Roles.Admin)*/]
        public async Task<ActionResult<Advert>> DeleteAdvert(int id)
        {
            var result = _advertService.DeleteAdvert(id);
            if (result == null)
                return NotFound("İlan Bulunamadı!");
            string m = _advertService.DeleteAdvert(id).Message;
            return Ok(m);
        }
    }  
}