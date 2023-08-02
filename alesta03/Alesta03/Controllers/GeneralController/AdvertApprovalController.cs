using Alesta03.Model;
using Alesta03.Request.AddvertApprovalRequest;
using Alesta03.Request.AdvetRequest;
using Alesta03.Response.AdvertApproval_Response;
using Alesta03.Response.AdvertResponse;
using Alesta03.Services.AdvertApprovalService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace Alesta03.Controllers.GeneralController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertApprovalController : ControllerBase
    {
        private readonly DataContext _context;

        public AdvertApprovalController(DataContext context)
        {
            _context = context;
        }

        [HttpGet, Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<AdvertApproval>> GetAdvertApproval()//Herkesin ilanı kendine!!!.
        {
            var userMail = User?.Identity?.Name;

            var user = _context.Users.FirstOrDefault(u => u.Email == userMail);

            var userId = user?.ID;

            var userAdverts = _context.Adverts.Where(a => a.UserId == userId).ToList();

            var userAdvertApprovals = new List<GetAdvertApprovalResponse>();
            foreach (var advert in userAdverts)
            {
                var advertApprovals = _context.AdvertApprovals
                    .Where(aa => aa.AdvertId == advert.Id)
                    .Select(aa => new GetAdvertApprovalResponse
                    {
                        AppName = aa.AppName,
                        AppSurname = aa.AppSurname,
                        AppSchool=aa.AppSchool,
                        AppAvg = aa.AppAvg, 
                    })
                    .ToList();
                userAdvertApprovals.AddRange(advertApprovals);
            }
            return Ok(userAdvertApprovals);
        }

        [HttpGet("{advertId}"), Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<AdvertApproval>> GetAdvertApproval(int advertId)
        {
            var userMail = User?.Identity?.Name;

            var user = _context.Users.FirstOrDefault(u => u.Email == userMail);

            var userId = user?.ID;

            var advert = _context.Adverts.FirstOrDefault(a => a.Id == advertId && a.UserId == userId);

            if (advert == null)
            {
                return NotFound("İlan bulunamadı veya size ait değil.");
            }

            var advertApprovals = _context.AdvertApprovals
                .Where(aa => aa.AdvertId == advert.Id)
                .Select(aa => new GetAdvertApprovalResponse
                {
                    AppName = aa.AppName,
                    AppSurname = aa.AppSurname,
                    AppSchool=aa.AppSchool,
                    AppAvg = aa.AppAvg,
                    ApproveDate = aa.ApproveDate
                })
                .ToList();
            return Ok(advertApprovals);

        }

        [HttpDelete("{id}"), Authorize(Roles = Role.User)]
        public async Task<ActionResult<List<AdvertApproval>>> DeleteApproveAdvert(int id)
        {
            AdvertApproval model = new AdvertApproval();
            var control = model.IsDeleted;
            var review = await _context.AdvertApprovals.FindAsync(id);
            if (review is null)
                return null;
            if (control is true)
                return null;
            model.IsDeleted = review.IsDeleted;
            model.IsDeleted = true;
            model.Status = "Henüz başvuru yapılmadı.";

            DeleteAdvertResponse response = new DeleteAdvertResponse();
            await _context.SaveChangesAsync();
            return Ok(response);
        }

        [HttpPost, Authorize(Roles = Role.User)]
        public async Task<ActionResult<List<AdvertApproval>>> ApplyAdvert(ApplyAdvertRequest request)
        {

            var userMail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == userMail);
            var id = user?.ID;
            if (user == null)
                return NotFound("Kullanıcı Bulunamadı!");


            var userData = await _context.Users
                .Include(u => u.People)
        .           ThenInclude(p => p.EduStatuses)
                     .ThenInclude(e => e.BackEdu)
                        .FirstOrDefaultAsync(u => u.ID == id);

            if (userData == null)
            {
                return NotFound("Kullanıcı bilgileri bulunamadı.");
            }

            var personData = userData.People.FirstOrDefault();
            var backEduData = personData?.EduStatuses.FirstOrDefault()?.BackEdu;

            if (personData == null || backEduData == null)
            {
                return NotFound("Kişi veya Eğitim Bilgisi bulunamadı.");
            }

            var model = _context.AdvertApprovals.FirstOrDefault(x => x.UserId == id);
            if (model is not null) return NotFound("Başvuru!!!");

            model.UserId = id;
            model.AdvertId = request.AdvertId;
            model.AppName = personData.Name;
            model.AppSurname = personData.Surname;
            model.AppSchool = backEduData.SchoolName;
            model.AppAvg = backEduData.Avg;
            model.Status = "Başvuru gerçekleştirildi.";

            _context.AdvertApprovals.Add(model);
            await _context.SaveChangesAsync();

            ApplyAdvertResponse response = new ApplyAdvertResponse();

            response.AppName=model.AppName;
            response.AppSurname = model.AppSurname;
            response.AppSchool = model.AppSchool;
            response.AppAvg = model.AppAvg;
            response.Status=model.Status;
            response.ApproveDate = DateTime.Now;

            return Ok(response);
        }
    }
}
