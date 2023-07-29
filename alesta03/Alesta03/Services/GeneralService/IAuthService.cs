using Alesta03.Request.RgeisterRequest;
using Microsoft.AspNetCore.Mvc;

namespace Alesta03.Services.GeneralService
{
    public interface IAuthService
    {
        Task<ActionResult<User>> RegisterCompany(RegisterRequestUC request);
        Task<ActionResult<User>> RegisterPerson(RegisterRequestUP request);
    }
}
