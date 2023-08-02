using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alesta03.Controllers.CompanyController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyExpReviewController : ControllerBase
    {

        private readonly DataContext _context;
        public CompanyExpReviewController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Firmaya yazılanlar"), Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ExpReview>> GetSingleReviews()
        {
            var userMail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(x => x.Email == userMail);
            var id = user?.ID;

            var expReviews = await _context.ExpReviews
                 .Where(x => x.CompanyId == id)
                 .Select(u => new
                 {
                     title = u.Title,
                     description = u.Description,
                     Date = DateTime.Now,
                 }).ToListAsync();
            return Ok(expReviews);

        }
    }
}
