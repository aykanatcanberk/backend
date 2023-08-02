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

        [HttpGet, Authorize(Roles = Role.Admin)]
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
            var status = appStatus?.Status;

            var app = _context.WorkStatuses
                .Where(u => u.BackWorkId == bwid)
                .Where(x => status == "b")
                .Select(u => new
                {
                    name =u.Person.Name,
                    surname=u.Person.Surname,
                    companyName = cname,
                    companyEmail = mail,
                    departmentName = u.BackWork.DepartmentName,
                    employeeId = u.BackWork.EmployeeID,
                    appletter = u.BackWork.AppLetter,
                    startTime = u.BackWork.Start,
                    endTime = u.BackWork.End,
                    appStatus =status
                }).ToList();

            return Ok(app);
        }


        [HttpPut("deneyim onaylama"), Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ApprovalStatus>> PozitiveApp()
        {
            var mail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == mail);
            var id = user?.ID;

            var company = _context.Companies.FirstOrDefault(u => u.UsersId == id);
            var cid = company?.ID;

            var appStatus = _context.ApprovalStatuses.FirstOrDefault(u => u.CompanyId == cid);
            var status = appStatus?.Status;

            if (appStatus is not null)
                if (status is "b")
                    status= "o";

            await _context.SaveChangesAsync();

            return Ok("Deneyimi Onayladınız");
        }


        [HttpPut("deneyim reddetme"), Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ApprovalStatus>> NegativeApp()
        {
            var mail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == mail);
            var id = user?.ID;

            var company = _context.Companies.FirstOrDefault(u => u.UsersId == id);
            var cid = company?.ID;

            var appStatus = _context.ApprovalStatuses.FirstOrDefault(u => u.CompanyId == cid);
            var status = appStatus?.Status;

            if (appStatus is not null)
                if (status is "b")
                    status = "r";

            await _context.SaveChangesAsync();

            return Ok("Deneyimi Reddediniz");
        }

    }
}
