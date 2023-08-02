using Alesta03.Request.AddRequest;
using Alesta03.Request.UpdateRequest;
using Alesta03.Response.AddResponse;
using Alesta03.Response.GetResponse;
using Alesta03.Response.UpdateResponse;
using Alesta03.Services.PersonServices.InfoService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alesta03.Controllers.PersonController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonInfoWorkController : ControllerBase
    {

        private readonly DataContext _context;
        public PersonInfoWorkController(DataContext context)
        {
            _context = context;
        }

        [HttpGet, Authorize(Roles = Role.User)]
        public async Task<ActionResult<BackWork>> GetSingleWork()
        {
            var mail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == mail);
            var id = user?.ID;

            if (user == null) return NotFound("Kullanıcı Bulunumadı!");

            var person = _context.People.FirstOrDefault(u => u.UsersId == id);
            var pid = person?.ID;

            if (person == null) return NotFound("Kişi Bulunumadı!");
              
            var model = _context.WorkStatuses.FirstOrDefault(x =>x.PersonId == pid);

            if (model == null) return NotFound("Kişi İş Bilgisi Bulunamadı!");
                
            var pwid = model.BackWorkId;
            var backWork = _context.BackWorks.FirstOrDefault(x => x.ID == pwid);

            if (backWork == null) return NotFound("Kişi İş Geçmişi Bulunamadı!");

            var bpwid = backWork.ID;
            var app = _context.ApprovalStatuses.FirstOrDefault(x => x.BackWorkId == bpwid);
            var appStatus = app?.Status;
            var appCIP = app?.CompanyId;

            var company = _context.Companies.FirstOrDefault(x => x.ID == appCIP);

            GetBackWorkResponse response = new GetBackWorkResponse();

            response.CompanyMail = company.Users.Email;
            response.DepartmentName = backWork.DepartmentName;
            response.EmployeeID = backWork.EmployeeID;
            response.AppLetter = backWork.AppLetter;
            response.Start = backWork.Start;
            response.End = backWork.End;
            response.appStatus = appStatus;

            return Ok(response);
        }

        [HttpPut, Authorize(Roles = Role.User)]
        public async Task<ActionResult<BackWork>> UpdateWorkInfo(UpdateInfoWorkRequest request)
        {
            var mail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == mail);
            var id = user?.ID;

            if (user == null) return NotFound("Kişi Bulunumadı!");

            var person = _context.People.FirstOrDefault(u => u.UsersId == id);
            var pid = person?.ID;

            if (person == null) return NotFound("Kişi Bulunumadı!");

            var model = _context.WorkStatuses.FirstOrDefault(x => x.PersonId == pid);
            if (model == null) return NotFound("Kişi İş Bilgisi Bulunamadı!");

            var pwid = model.BackWorkId;

            var backWork = _context.BackWorks.FirstOrDefault(x => x.ID == pwid);
            if (backWork == null) return NotFound("Kişi İş Geçmişi Bulunamadı!");

            var bpwid = backWork.ID;
            var app = _context.ApprovalStatuses.FirstOrDefault(x => x.BackWorkId == bpwid);
            var appStatus = app?.Status;
            var appCIP = app?.CompanyId;

            var company = _context.Companies.FirstOrDefault(x => x.ID == appCIP);

            company.Users.Email= request.CompanyMail;
            backWork.DepartmentName = request.DepartmentName;
            backWork.EmployeeID = request.EmployeeID;
            backWork.AppLetter = request.AppLetter;
            backWork.Start = request.Start; 
            backWork.End = request.End;

            UpdateInfoWorkResponse response = new UpdateInfoWorkResponse
            {
                CompanyName = company.Name,
                DepartmentName = backWork.DepartmentName,
                EmployeeID = backWork.EmployeeID,
                AppLetter = backWork.AppLetter,
                Start = backWork.Start,
                End = backWork.End
            };

            await _context.SaveChangesAsync();

            return Ok(response);
        }

        [HttpPost, Authorize(Roles = Role.User)]
        public async Task<ActionResult<BackWork>> AddWorkInfo(AddInfoWorkRequest request)
        {
            var mail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == mail);
            var id = user?.ID;

            if (user == null)
                return NotFound("Kişi Bulunumadı!");

            BackWork model = new BackWork();


            model.CompanyMail = request.CompanyEmail;
            model.DepartmentName = request.DepartmentName;
            model.EmployeeID = request.EmployeeID;
            model.AppLetter = request.AppLetter;
            model.Start = request.Start;
            model.End = request.End;
            
            _context.BackWorks.Add(model);
            await _context.SaveChangesAsync();

            AddInfoWorkResponse response = new AddInfoWorkResponse();

            response.CompanyEmail = model.CompanyMail;
            response.DepartmentName = model.DepartmentName;
            response.EmployeeID = model.EmployeeID;
            response.AppLetter = model.AppLetter;
            response.Start = model.Start;
            response.End = model.End;


            WorkStatus workStatus = new WorkStatus();

            var person = _context.People.FirstOrDefault(u => u.UsersId == id);
            var pid = person?.ID;

            workStatus.BackWorkId = model.ID;
            workStatus.PersonId = pid;

            _context.WorkStatuses.Add(workStatus);
            await _context.SaveChangesAsync();

            ApprovalStatus approval = new ApprovalStatus();

            var workSta = _context.WorkStatuses.FirstOrDefault(x => x.PersonId == pid);
            var pwid = workSta?.BackWorkId;
            var backWork = _context.BackWorks.FirstOrDefault(x => x.ID == pwid);
            var bpwid = backWork?.ID;

            var k = _context.Companies.FirstOrDefault(x => x.Users.Email == model.CompanyMail);
            var copmanyid = k?.ID;

            approval.Status = string.Empty;
            approval.BackWorkId = bpwid;
            approval.CompanyId = copmanyid;

            _context.ApprovalStatuses.Add(approval);
            await _context.SaveChangesAsync();
            
            return Ok(response);
        }

        [HttpGet("get all"), Authorize(Roles = Role.User)]
        public async Task<ActionResult<List<BackWork>>> GetAll()
        {
            var backEdu = await _context.BackWorks.ToListAsync();

            return Ok(backEdu);
        }
    }
}
