using Alesta03.Request.UpdateRequest;
using Alesta03.Response.UpdateResponse;

namespace Alesta03.Services.PersonServices.InfoService
{
    public interface IPersonInfoWorkService
    {
        Task<List<BackWork>> GetAllWorks();
        Task<BackWork?> GetSingleWork(int id);
        Task<UpdateInfoWorkResponse?> UpdateWorkInfo(int id, UpdateInfoWorkRequest request);
    }
}
