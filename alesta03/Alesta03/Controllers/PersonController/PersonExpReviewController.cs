using Alesta03.Model;
using Alesta03.Request.AddRequest;
using Alesta03.Request.UpdateRequest;
using Alesta03.Response.AddResponse;
using Alesta03.Response.UpdateResponse;
using Alesta03.Services.PersonServices.ExpReviewService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Xml.Linq;


namespace Alesta03.Controllers.PersonController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonController(DataContext context)
        {
            _context = context;
        }


        [HttpPost, Authorize(Roles = Role.User)]
        public async Task<ActionResult<ExpReview>> AddReview(AddReviewRequest request)
        {
            var userMail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(x => x.Email == userMail);
            var id = user?.ID;

            var person = _context.People.FirstOrDefault(u => u.UsersId == id);
            var pid = person?.ID;
            var name = person?.Name;
            var surname = person?.Surname;

            var workStatus = _context.WorkStatuses.FirstOrDefault(x => x.PersonId == pid);
            var pwid = workStatus?.BackWorkId;

            var backWork = _context.BackWorks.FirstOrDefault(x => x.ID == pwid);
            var bpwid = backWork?.ID;

            var appStatus = _context.ApprovalStatuses.FirstOrDefault(x => x.BackWorkId == bpwid);
            
            if (appStatus == null) return NotFound("Kullanıcı Bulunamadı");
            if (appStatus.Status is "b") return BadRequest("Yetkiniz Bulunamamkta");
            else if (appStatus.Status is "r") return BadRequest("Yetkiniz Bulunamamkta");

            var eml = backWork?.CompanyMail;
            var k = _context.Companies.FirstOrDefault(x => x.Users.Email == eml);
            var copmanyid = k?.ID;
            var cname = k?.Name;

            ExpReview expReview = new ExpReview();

            expReview.PersonId = pid;
            expReview.Title = request.Title; 
            expReview.Description = request.Description;
            expReview.CompanyId = copmanyid;
            

            _context.ExpReviews.Add(expReview);
            await _context.SaveChangesAsync();

            AddReviewResponse response = new AddReviewResponse();


            response.Title = expReview.Title;
            response.Description = expReview.Description;
            response.Date = DateTime.Now;
            response.Name = name;
            response.Surname = surname;
            response.CName = cname;

            return Ok(response);
        }

        [HttpGet("karışık"), Authorize(Roles = Role.User)]
        public async Task<ActionResult<List<ExpReview>>> GetAllReviews()
        {
            var expReviws = await _context.ExpReviews.ToListAsync();

            return Ok(expReviws);
        }

        [HttpGet("kişinin kendi yazdıkları"), Authorize(Roles = Role.User)]
        public async Task<ActionResult<ExpReview>> GetSingleReviews()
        {
            var userMail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(x => x.Email == userMail);
            var id = user?.ID;

            var expReviews = await _context.ExpReviews
                 .Where(x => x.PersonId== id)
                 .Select(u => new
                 {
                     title = u.Title,
                     description = u.Description,
                     Date = DateTime.Now,
                 }).ToListAsync();
            return Ok(expReviews);

        }

        [HttpPut, Authorize(Roles = Role.User)]
        public async Task<ActionResult<List<ExpReview>>> UpdateReview(UpdateReviewRequest request)
        {
            var mail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == mail);
            var id = user?.ID;


            if (user == null) return NotFound("Kişi Bulunumadı!");

            var person = _context.People.FirstOrDefault(u => u.UsersId == id);
            var pid = person?.ID; 

            if (person == null) return NotFound("Kişi Bulunumadı!");

            var name = person?.Name;
            var surname = person?.Surname;

            var workStatus = _context.WorkStatuses.FirstOrDefault(x => x.PersonId == pid);
            var pwid = workStatus?.BackWorkId;

            var backWork = _context.BackWorks.FirstOrDefault(x => x.ID == pwid);
            var bpwid = backWork?.ID;

            var eml = backWork?.CompanyMail;
            var k = _context.Companies.FirstOrDefault(x => x.Users.Email == eml);
            var copmanyid = k?.ID;
            var cname = k?.Name;

            var expReview = _context.ExpReviews.FirstOrDefault(x => x.PersonId == pid);

            expReview.PersonId = pid;
            expReview.Title = request.Title;
            expReview.Description = request.Description;
            expReview.CompanyId = copmanyid;

            _context.ExpReviews.Add(expReview);
            await _context.SaveChangesAsync();

            UpdateReviewResponse response = new UpdateReviewResponse();


            response.Title = expReview.Title;
            response.Description = expReview.Description;
            response.UpdateDate = DateTime.Now;

            return Ok(response);

        }



    }
}
