using Alesta03.Model;
using Alesta03.Request.UpdateRequest;
using Alesta03.Response.UpdateResponse;

namespace Alesta03.Services.PersonServices.InfoService
{
    public class PersonInfoEduService:IPersonInfoEduService
    {
        private static List<BackEdu> backEdus = new List<BackEdu>
            {
                new BackEdu
                {
                    ID = 1,
                    SchoolName = "ktün",
                    DepartmentName = "bilgisayar mühendisliği",
                    SchoolType = "lisans",
                    EduStatus = true,
                    Avg = 3.01f
                },
                new BackEdu
                {
                    ID = 2,
                    SchoolName = "kto",
                    DepartmentName = "elektrik elektronik mühendisliği",
                    SchoolType = "yüksek lisans",
                    EduStatus = true,
                    Avg = 2.01f
                }
        };
        private readonly DataContext _context;

        public PersonInfoEduService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BackEdu>> GetAllEdu()
        {
            var backEdus = await _context.BackEdus.ToListAsync();
            return backEdus;
        }

        public async Task<BackEdu?> GetSingleEdu(int id)
        {
            var backEdu = await _context.BackEdus.FindAsync(id);
            if (backEdu is null)
                return null;

            return backEdu;
        }

        public async Task<UpdateInfoEduResponse?> UpdateEduInfo(int id, UpdateInfoEduRequest request)
        {


            var model = await _context.BackEdus.FindAsync(id);

            if (model is null)
                return null;

            model.SchoolName = request.SchoolName;
            model.DepartmentName = request.DepartmentName;
            model.SchoolType = request.SchoolType;
            model.EduStatus = request.EduStatus;
            model.Avg = request.Avg;
                        
            UpdateInfoEduResponse response = new UpdateInfoEduResponse();

            response.SchoolName = model.SchoolName;
            response.DepartmentName = model.DepartmentName;
            response.SchoolType = model.SchoolType;
            response.EduStatus = model.EduStatus;
            response.Avg = model.Avg;
            response.UpdateDate = model.UpdateDate;

            await _context.SaveChangesAsync();

            return response;

        }

    }
}
