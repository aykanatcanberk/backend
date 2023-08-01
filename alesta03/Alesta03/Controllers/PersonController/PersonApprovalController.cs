using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alesta03.Controllers.PersonController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonApprovalController : ControllerBase
    {
        private readonly DataContext _context;
        public PersonApprovalController(DataContext context)
        {
            _context = context;
        }

        [HttpPut, Authorize(Roles = Role.User)]
        public async Task<ActionResult<Approval>> AppWork()
        {
            var userMail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(x => x.Email == userMail);
            var id = user?.ID;

            var person = _context.People.FirstOrDefault(u => u.UsersId == id);
            var pid = person?.ID;

            var workStatus = _context.WorkStatuses.FirstOrDefault(x => x.PersonId == pid);
            var pwid = workStatus?.BackWorkId;

            var backWork = _context.BackWorks.FirstOrDefault(x => x.ID == pwid);
            var bpwid = backWork?.ID;

            var model = _context.Approvals.FirstOrDefault(x => x.BackWorkId == bpwid);

            if (model == null) return NotFound("Kullanıcı Bulunamadı");

            if (model.ApprovalStatus is "b") return BadRequest("Başvurunuz Tarafımıza Daha Öncesinde İletilmiştir.");
            else if (model.ApprovalStatus is "r") return BadRequest("Başvurunuz Reddeilmiştir.");
            else if (model.ApprovalStatus is "o") return BadRequest("Başvurunuz Onaylanmıştır.");
            else if (model.ApprovalStatus is "")
            {
                model.ApprovalStatus = "b";
            }
            

            await _context.SaveChangesAsync();

            return Ok("İş Deneyiminiz Onaya Gönderildi");
        }
         
    }
}
