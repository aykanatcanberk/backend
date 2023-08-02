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
        public async Task<ActionResult<ApprovalStatus>> AppWork()
        {
            var userMail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(x => x.Email == userMail);
            var id = user?.ID;
            if (user is null) return Ok("Kullanıcı Bulunamadı!");
            
            var person = _context.People.FirstOrDefault(u => u.UsersId == id);
            var pid = person?.ID;
            if (person is null) return Ok("Kişi Bulunamadı!");

            var workStatus = _context.WorkStatuses.FirstOrDefault(x => x.PersonId == pid);
            var pwid = workStatus?.BackWorkId;
            if (workStatus is null) return Ok("Kişi İş Durumu Bulunamadı");

            var backWork = _context.BackWorks.FirstOrDefault(x => x.ID == pwid);
            var bpwid = backWork?.ID;

            if (backWork is null) return Ok("Kişi iş Geçmişi Bulunamadı");

            var model = _context.ApprovalStatuses.FirstOrDefault(x => x.BackWorkId == bpwid);

            if (model == null) return NotFound("Kişi Onay Durumu Bulunamadı!");

            if (model.Status is "b") return BadRequest("Başvurunuz Tarafımıza Daha Öncesinde İletilmiştir.");
            else if (model.Status is "r") return BadRequest("Başvurunuz Reddeilmiştir.");
            else if (model.Status is "o") return BadRequest("Başvurunuz Onaylanmıştır.");
            else if (model.Status is "")
            {
                model.Status = "b";
            }
            

            await _context.SaveChangesAsync();

            return Ok("İş Deneyiminiz Onaya Gönderildi");
        }
         
    }
}
