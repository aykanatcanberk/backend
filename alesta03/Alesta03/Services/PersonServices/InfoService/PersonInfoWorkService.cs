using Alesta03.Request.UpdateRequest;
using Alesta03.Response.UpdateResponse;

namespace Alesta03.Services.PersonServices.InfoService
{
    public class PersonInfoWorkService:IPersonInfoWorkService
    {
        private static List<BackWork> backWorks = new List<BackWork>
            {
                new BackWork
                {
                    ID = 1,
                    CompanyName = "vizyonergenc",
                    DepartmentName = "yazılım",
                    StartTime = new DateTime(2023,07,10),
                    EndTime = new DateTime(2023,08,04)
    },
                new BackWork
                {
                    ID = 2,
                    CompanyName = "havelsan",
                    DepartmentName = "donanım",
                    StartTime = new DateTime(2023,07,10),
                    EndTime = new DateTime(2023,08,04)
                }
        };

        public List<BackWork> GetAllWorks()
        {
            return backWorks;
        }

        public BackWork? GetSingleWork(int id)
        {
            var backWork = backWorks.Find(x => x.ID == 1);
            if (backWork is null)
                return null;

            return backWork;
        }

        public UpdateInfoWorkResponse? UpdateWorkInfo(int id, UpdateInfoWorkRequest request)
        {
            BackWork model = new BackWork();

            model = backWorks.Find(x => x.ID == id);

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

            return response;

        }
    }
}
