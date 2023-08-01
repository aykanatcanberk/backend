using Alesta03.Model;
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
    public class PersonInfoEduController : ControllerBase
    {

        private readonly DataContext _context;
        public PersonInfoEduController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("get single"), Authorize(Roles = Role.User)]
        public async Task<ActionResult<List<BackEdu>>> GetSingleEdu()
        {
            var mail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == mail);
            var id = user?.ID;

            if (user == null)
                return NotFound("Kullanıcı Bulunumadı!");

            var person = _context.People.FirstOrDefault(u => u.UsersId == id);
            var pid = person?.ID;

            if (person == null)
                return NotFound("Kişi Bulunumadı!");

            var model = _context.EduStatuses.FirstOrDefault(x => x.PersonId == pid);
            if (model == null)
                return NotFound("Kişi Eğitim Bilgisi Bulunamadı!");

            var pwid = model.BackEduId;

            var backEdu = _context.BackEdus.FirstOrDefault(x => x.ID == pwid);
            if (backEdu == null)
                return NotFound("Kişi Eğitim Geçmişi Bulunamadı!");

            GetBackEduResponse response = new GetBackEduResponse();

            response.SchoolName = backEdu.SchoolName;
            response.DepartmentName = backEdu.DepartmentName;
            response.SchoolType = backEdu.SchoolType;
            response.EduStatus = backEdu.EduStatus;
            response.Avg = backEdu.Avg;

            return Ok(response);
        }

        [HttpPut, Authorize(Roles = Role.User)]
        public async Task<ActionResult<BackEdu>> UpdateEduInfo(UpdateInfoEduRequest request)
        {

            var mail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == mail);
            var id = user?.ID;

            if (user == null)
                return NotFound("Kullanıcı Bulunumadı!");

            var person = _context.People.FirstOrDefault(u => u.UsersId == id);
            var pid = person?.ID;

            if (person == null)
                return NotFound("Kişi Bulunumadı!");

            var model = _context.EduStatuses.FirstOrDefault(x => x.PersonId == pid);
            if (model == null)
                return NotFound("Kişi Eğitim Bilgisi Bulunamadı!");

            var pwid = model.BackEduId;

            var backEdu = _context.BackEdus.FirstOrDefault(x => x.ID == pwid);
            if (backEdu == null)
                return NotFound("Kişi Eğitim Geçmişi Bulunamadı!");

            backEdu.SchoolName = request.SchoolName;
            backEdu.DepartmentName = request.DepartmentName;
            backEdu.SchoolType = request.SchoolType;
            backEdu.EduStatus = request.EduStatus;
            backEdu.Avg = request.Avg;
            
            UpdateInfoEduResponse response = new UpdateInfoEduResponse();

            response.SchoolName = backEdu.SchoolName;
            response.DepartmentName = backEdu.DepartmentName;
            response.SchoolType = backEdu.SchoolType;
            response.EduStatus = backEdu.EduStatus;
            response.Avg = backEdu.Avg;
            response.UpdateDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(response);
        }

        [HttpPost, Authorize(Roles = Role.User)]
        public async Task<ActionResult<BackEdu>> AddEduInfo(AddInfoEduRequest request)
        {
            var mail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == mail);
            var id = user?.ID;

            if (user == null)
                return NotFound("Kişi Bulunumadı!");

            BackEdu model = new BackEdu();

            model.SchoolName = request.SchoolName;
            model.DepartmentName = request.DepartmentName;
            model.SchoolType = request.SchoolType;
            model.EduStatus = request.EduStatus;
            model.Avg = request.Avg;

            _context.BackEdus.Add(model);
            await _context.SaveChangesAsync();

            AddInfoEduResponse response = new AddInfoEduResponse();

            response.SchoolName = model.SchoolName;
            response.DepartmentName = model.DepartmentName;
            response.SchoolType = model.SchoolType;
            response.EduStatus = model.EduStatus;
            response.Avg = model.Avg;

            EduStatus eduStatus = new EduStatus();

            var person = _context.People.FirstOrDefault(u => u.UsersId == id);
            var pid = person?.ID;

            eduStatus.BackEduId = model.ID;
            eduStatus.PersonId = pid;

            _context.EduStatuses.Add(eduStatus);
            await _context.SaveChangesAsync();

            return Ok(response);
        }

        [HttpGet, Authorize(Roles = Role.User)]
        public async Task<ActionResult<List<BackEdu>>> GetAll()
        {
            var mail = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == mail);
            var id = user?.ID;

            var person = _context.People.FirstOrDefault(u => u.UsersId == id);
            var pid = person?.ID;


            var backedu = _context.WorkStatuses
                .Where(u => u.PersonId == pid)
                .Select(u => new
                {
                    companyName = u.BackWork.CompanyName,
                    companyEmail = u.BackWork.CompanyEmail,
                    departmentName = u.BackWork.DepartmentName,
                    employeeId = u.BackWork.EmployeeID,
                    appletter = u.BackWork.AppLetter,
                    startTime = u.BackWork.Start,
                    endTime = u.BackWork.End
                }).ToList();

            return Ok(backedu);
        }
    }
}
