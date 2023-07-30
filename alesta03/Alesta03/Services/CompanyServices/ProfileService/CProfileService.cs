using Alesta03.Controllers.GeneralController;
using Alesta03.Model;
using Alesta03.Request.AddRequest;
using Alesta03.Request.UpdateRequest;
using Alesta03.Response.AddResponse;
using Alesta03.Response.UpdateResponse;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Alesta03.Services.CompanyServices.ProfileService
{
    public class CProfileService:ICProfileService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public CProfileService(DataContext context,IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }


        public async Task<List<Company>> GetAllProfiles()
        {
            var companies = await _context.Companies.ToListAsync();
            return companies;
        }

        public async Task<Company?> GetSingleProfiles(int Id)
        {
            var company = await _context.Companies.FindAsync(Id);
            if (company is null)
                return null;

            return company;
        }

        public async Task<UpdateCProfileResponse?> UpdateProfile(int id, UpdateCProfileRequest request)
        {
           
            var model = await _context.Companies.FindAsync(id);

            if (model is null)
                return null;

            model.Category = request.Category;
            model.Type = request.Type;
            model.Name = request.Name;
            model.Description = request.Description;
            model.FDate = request.FDate;
            model.TotalStaff = request.TotalStaff;
            model.Location = request.Location;
            model.Prof = request.Prof;
            model.Phone = request.Phone;
            model.Website = request.Website;

            UpdateCProfileResponse response = new UpdateCProfileResponse();

            response.Category = model.Category;
            response.Type = model.Type;
            response.Name = model.Name;
            response.Description = model.Description;
            response.FDate = model.FDate;
            response.TotalStaff = model.TotalStaff;
            response.Location = model.Location;
            response.Prof = model.Prof;
            response.Phone = model.Phone;
            response.Website = model.Website;
            response.UpdateDate = model.UpdateDate;

            await _context.SaveChangesAsync();

            return response;

        }

        
        //public async Task<AddCProfileResponse> AddProfileInfo(AddCProfileRequest request)
        //{
        //    var mail = string.Empty;
        //    if(_contextAccessor.HttpContext is not null)
        //    {
        //        mail = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        //    }

        //    var user = _context.Users.FirstOrDefault(u => u.Email == mail);
        //    if (user != null) 
        //        return null;

        //    var id = user.ID;

        //    Company model = new Company();

        //    model.UsersId = id;
        //    model.Category = request.Category;
        //    model.Type = request.Type;
        //    model.Name = request.Name;
        //    model.Description = request.Description;
        //    model.FDate = request.FDate;
        //    model.TotalStaff = request.TotalStaff;
        //    model.Location = request.Location;
        //    model.Prof = request.Prof;
        //    model.Phone = request.Phone;
        //    model.Website = request.Website;

        //    _context.Companies.Add(model);
            
        //    AddCProfileResponse response = new AddCProfileResponse();

        //    response.Category = model.Category;
        //    response.Type = model.Type;
        //    response.Name = model.Name;
        //    response.Description = model.Description;
        //    response.FDate = model.FDate;
        //    response.TotalStaff = model.TotalStaff;
        //    response.Location = model.Location;
        //    response.Prof = model.Prof;
        //    response.Phone = model.Phone;
        //    response.Website = model.Website;
        //    response.UsersId = model.UsersId;

        //    await _context.SaveChangesAsync();

        //    return response;
        //}
    }
}
