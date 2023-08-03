using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Alesta03.Controllers.CompanyController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListAppController : ControllerBase
    {
        private readonly DataContext _context;

        public ListAppController(DataContext context)
        {
            _context = context;
        }

        [HttpGet(), Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<List<BackWork>>> GetAllApp()
        {
            var mail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == mail);
            var id = user?.ID;

            var company = _context.Companies.FirstOrDefault(u => u.UsersId == id);
            var cid = company?.ID;
            var cname = company?.Name;           

            var appStatus = _context.ApprovalStatuses.FirstOrDefault(u => u.CompanyId == cid);
            var bwid = appStatus?.BackWorkId;


            var app = await _context.WorkStatuses
                .Where(x => appStatus.Status == "b")
                .ToListAsync();

            return Ok(app);
        }


        [HttpPut("deneyim onaylama,{deneyimId,backWorkId}"), Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ApprovalStatus>> PozitiveApp(int reviewId,int backWorkId)
        {
            var expReview = _context.ExpReviews.FirstOrDefault(x => x.ID == reviewId);
            var pid = expReview?.PersonId;

            var appStatus = _context.ApprovalStatuses.FirstOrDefault(x => x.PersonId==pid &&  x.BackWorkId == backWorkId);
            var status = appStatus?.Status;

            if (appStatus is null) return BadRequest("Deneyim bulunamadı");

            if (appStatus.Status is "b")
            {
                ApprovalStatus model = new ApprovalStatus();

                model.Status = "o";
                await _context.SaveChangesAsync();
            }

            return Ok("Deneyimi Onayladınız");
        }

        [HttpPut("deneyim reddetme,{deneyimId}"), Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ApprovalStatus>> NegativeApp(int reviewId)
        {
            var expReview = _context.ExpReviews.FirstOrDefault(x => x.ID == reviewId);
            var pid = expReview?.PersonId;

            var appStatus = _context.ApprovalStatuses.FirstOrDefault(x => x.PersonId == pid);

            if (appStatus is null) return BadRequest("Deneyim bulunamadı");

            if (appStatus.Status is "b")
            {
                ApprovalStatus model = new ApprovalStatus();

                model.Status = "r";
                await _context.SaveChangesAsync();
            }

            return Ok("Deneyimi Reddeddiniz");
        }

    }
}
