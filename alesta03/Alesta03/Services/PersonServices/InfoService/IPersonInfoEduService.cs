using Alesta03.Request.UpdateRequest;
using Alesta03.Response.UpdateResponse;

namespace Alesta03.Services.PersonServices.InfoService
{
    public interface IPersonInfoEduService
    {
        Task<List<BackEdu>> GetAllEdu();
        Task<BackEdu?> GetSingleEdu(int id);
        Task<UpdateInfoEduResponse?> UpdateEduInfo(int id, UpdateInfoEduRequest request);
    }
}
