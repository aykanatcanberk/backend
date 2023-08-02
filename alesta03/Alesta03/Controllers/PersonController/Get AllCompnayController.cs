using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alesta03.Controllers.PersonController
{
    [Route("api/[controller]")]
    [ApiController]
    public class Get_AllCompnayController : ControllerBase
    {
        private readonly DataContext _context;

        public Get_AllCompnayController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("get all company"), Authorize(Roles = Role.User)]
        public async Task<ActionResult<List<Company>>> GetAll()
        {
            var companies = await _context.Companies.ToListAsync();

            return Ok(companies);
        }
    }
}
