using Alesta03.Request.AddvertApprovalRequest;
using Alesta03.Request.AdvetRequest;
using Alesta03.Services.AdvertApprovalService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alesta03.Controllers.GeneralController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertApprovalController : ControllerBase
    {
        private readonly IAdvertApprovalService _advertAppovalService;
        
        public AdvertApprovalController(IAdvertApprovalService advertAppovalService)
        {
            _advertAppovalService = advertAppovalService;
        }
        [HttpGet/*, Authorize(Roles = Role.Admin)*/]
        public async Task<ActionResult<AdvertApproval>> GetAdvertApproval()
        {
            var result = await _advertAppovalService.GetAdvertApproval();

            if (result == null || result.Count == 0)
                return NotFound("Başvuru bulunamadı.");
            return Ok(result);
        }

        [HttpDelete("{id}")/*, Authorize(Roles = Role.Admin)*/]
        public async Task<ActionResult<List<AdvertApproval>>> DeleteApproveAdvert(int id)
        {
            var result = await _advertAppovalService.DeleteApproveAdvert(id);
            if (result == null)
                return NotFound("İlan bulunamadı.");
            return Ok(result);
        }

        [HttpPost/*, Authorize(Roles = Role.User)*/]
        public async Task<ActionResult<List<Advert>>> ApplyAdvert(ApplyAdvertRequest request)
        {
            var result = await _advertAppovalService.ApplyAdvert(request);
            return Ok(result);
        }


    }
}
