using Alesta03.Request.UpdateRequest;
using Alesta03.Response.UpdateResponse;

namespace Alesta03.Services.PersonServices.InfoService
{
    public interface IPersonInfoEduService
    {
        List<BackEdu> GetAllEdu();
        BackEdu? GetSingleEdu(int id);
        UpdateInfoEduResponse? UpdateEduInfo(int id, UpdateInfoEduRequest request);
    }
}
