using Alesta03.Request.AddRequest;
using Alesta03.Request.UpdateRequest;
using Alesta03.Response.AddResponse;
using Alesta03.Services.PersonServices.ExpReviewService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


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
            var cname = backWork?.CompanyName;
            var cid = backWork?.companyID;
            
            var model = _context.Approvals.FirstOrDefault(x => x.BackWorkId == bpwid);


            if (model == null) return NotFound("Kullanıcı Bulunamadı");
            if (model.ApprovalStatus is "b") return BadRequest("Yetkiniz Bulunamamkta");
            else if (model.ApprovalStatus is "r") return BadRequest("Yetkiniz Bulunamamkta");



            ExpReview expReview = new ExpReview();

            expReview.PersonId = pid;
            expReview.Title = request.Title; 
            expReview.Description = request.Description;
            expReview.CompanyId = cid;
            

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

        //[HttpGet, Authorize(Roles = Role.User)]
        //public async Task<ActionResult<List<ExpReview>>> GetAllReviews()
        //{
        //}

        //[HttpGet, Authorize(Roles = Role.User)]
        //public async Task<ActionResult<ExpReview>> GetSingleReviews(int id)
        //{
        //}

        //[HttpPut, Authorize(Roles = Role.User)]
        //public async Task<ActionResult<List<ExpReview>>> UpdateReview(int id, UpdateReviewRequest request)
        //{
        //}



    }
}
