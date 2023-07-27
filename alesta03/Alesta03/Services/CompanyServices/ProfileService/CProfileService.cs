using Alesta03.Model;
using Alesta03.Request.UpdateRequest;
using Alesta03.Response.UpdateResponse;

namespace Alesta03.Services.CompanyServices.ProfileService
{
    public class CProfileService:ICProfileService
    {
        private static List<Company> companies = new List<Company>
            {
                new Company
                {
                    ID = 1,
                    Category = "Savunma Sanayii",
                    Type = "Özel Şirket",
                    Name = "ROKETSAN",
                    Description = "Description",
                    FDate = "1988",
                    TotalStaff = 50000,
                    Location = "Ankara,Elmadağ",
                    Prof = "Mühendislik ve Teknoloji",
                    Phone = "000000000",
                    Website = "mmmmmmmm"
                },
                new Company
                {
                    ID = 2,
                    Category = "Savunma Sanayii",
                    Type = "Özel Şirket",
                    Name = "HAVELSAN",
                    Description = "Description",
                    FDate = "1988",
                    TotalStaff = 50000,
                    Location = "Ankara,Elmadağ",
                    Prof = "Mühendislik ve Teknoloji",
                    Phone = "000000000",
                    Website = "mmmmmmmm"

                }
        };


        public List<Company> GetAllProfiles()
        {
            return companies;
        }

        public Company? GetSingleProfiles(int Id)
        {
            var company = companies.Find (x => x.ID == Id);
            if (company is null)
                return null;

            return company;
        }

        public UpdateCProfileResponse? UpdateProfile(int id, UpdateCProfileRequest request)
        {
            Company model = new Company();

            model = companies.Find(x => x.ID == id);

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

            return response;

        }
    }
}
