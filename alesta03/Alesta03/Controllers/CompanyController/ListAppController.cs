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

            var app = _context.WorkStatuses
                .Where(u => u.BackWork.companyID == cid)
                .Where(x => x.BackWork.Approval.ApprovalStatus == "b")
                .Select(u => new
                {
                    name =u.Person.Name,
                    surname=u.Person.Surname,
                    companyName = u.BackWork.CompanyName,
                    companyEmail = u.BackWork.CompanyEmail,
                    departmentName = u.BackWork.DepartmentName,
                    employeeId = u.BackWork.EmployeeID,
                    appletter = u.BackWork.AppLetter,
                    startTime = u.BackWork.Start,
                    endTime = u.BackWork.End,
                    appStatus =u.BackWork.Approval.ApprovalStatus
                }).ToList();

            return Ok(app);
        }


        [HttpPut("deneyim onaylama"), Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<Approval>> PozitiveApp()
        {
            var mail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == mail);
            var id = user?.ID;

            var company = _context.Companies.FirstOrDefault(u => u.UsersId == id);
            var cid = company?.ID;

            var approval = _context.Approvals.FirstOrDefault(x => x.BackWork.companyID == cid);
            if (approval is not null)
                if (approval.ApprovalStatus is "b")
                    approval.ApprovalStatus = "o";

            await _context.SaveChangesAsync();

            return Ok("Deneyimi Onayladınız");
        }


        [HttpPut("deneyim reddetme"), Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<Approval>> NegativeApp()
        {
            var mail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == mail);
            var id = user?.ID;

            var company = _context.Companies.FirstOrDefault(u => u.UsersId == id);
            var cid = company?.ID;

            var approval = _context.Approvals.FirstOrDefault(x => x.BackWork.companyID == cid);
            if (approval is not null)
                if (approval.ApprovalStatus is "b")
                    approval.ApprovalStatus = "r";

            await _context.SaveChangesAsync();

            return Ok("Deneyimi Reddediniz");
        }

    }
}
