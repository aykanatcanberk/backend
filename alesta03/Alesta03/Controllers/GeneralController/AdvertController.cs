using Alesta03.Request.AdvetRequest;
using Alesta03.Request.PostRequest;
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
        private readonly IAdvertService _advertService;

        public AdvertController(IAdvertService advertService)
        {
            _advertService = advertService;
        }


        [HttpGet]
        public async Task<ActionResult<Advert>> GetAllAdvert()
        {
            var result = await _advertService.GetAllAdvert();

            if (result == null || result.Count == 0)
                return NotFound("İlan bulunamadı.");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Advert>> GetSingleAdvert(int id)
        {
            var result = await _advertService.GetSingleAdvert(id);
            if (result == null)
                return NotFound("İlan Bulunamadı.");

            return Ok(result);
        }

        [HttpPost/*, Authorize(Roles = Role.Admin)*/]
        public async Task<ActionResult<List<Advert>>> AddAdvert(AddAdvertRequest request)
        {
            var result = await _advertService.AddAdvert(request);
            return Ok(result);
        }


        [HttpDelete("{id}")/*, Authorize(Roles = Role.Admin)*/]
        public async Task<ActionResult<List<Advert>>> DeleteAdvert(int id)
        {
            var result = await _advertService.DeleteAdvert(id);
            if (result == null)
                return NotFound("İlan bulunamadı.");
            return Ok(result);
        }
    }
}
