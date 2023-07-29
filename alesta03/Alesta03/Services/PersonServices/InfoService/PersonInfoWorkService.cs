using Alesta03.Request.UpdateRequest;
using Alesta03.Response.UpdateResponse;

namespace Alesta03.Services.PersonServices.InfoService
{
    public class PersonInfoWorkService:IPersonInfoWorkService
    {
        private readonly DataContext _context;
        public PersonInfoWorkService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<BackWork>> GetAllWorks()
        {
            var backWorks = await _context.BackWorks.ToListAsync();
            return backWorks;
        }

        public async Task<BackWork?> GetSingleWork(int id)
        {
            var backWork = await _context.BackWorks.FindAsync(id);
            if (backWork is null)
                return null;

            return backWork;
        }

        public async Task<UpdateInfoWorkResponse?> UpdateWorkInfo(int id, UpdateInfoWorkRequest request)
        {
            var model = await _context.BackWorks.FindAsync(id);

            if (model is null)
                return null;

            model.CompanyName = request.CompanyName;
            model.DepartmentName = request.DepartmentName;
            model.StartTime = request.StartTime;
            model.EndTime = request.EndTime;

            UpdateInfoWorkResponse response = new UpdateInfoWorkResponse(); 

            response.CompanyName = model.CompanyName;
            response.DepartmentName = model.DepartmentName;
            response.StartTime = model.StartTime;
            response.EndTime = model.EndTime;
            response.UpdateDate = model.UpdateDate;

            await _context.SaveChangesAsync();

            return response;

        }
    }
}
