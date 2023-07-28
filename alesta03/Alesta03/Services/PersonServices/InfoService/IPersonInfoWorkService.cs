using Alesta03.Request.UpdateRequest;
using Alesta03.Response.UpdateResponse;

namespace Alesta03.Services.PersonServices.InfoService
{
    public interface IPersonInfoWorkService
    {
        List<BackWork> GetAllWorks();
        BackWork? GetSingleWork(int id);
        UpdateInfoWorkResponse? UpdateWorkInfo(int id, UpdateInfoWorkRequest request);
    }
}
