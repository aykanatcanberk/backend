using Alesta03.Request.UpdateRequest;
using Alesta03.Response.UpdateResponse;

namespace Alesta03.Services.PersonServices.ProfileService
{
    public class PProfileService : IPProfileService
    {
        private readonly DataContext _context;

        public PProfileService(DataContext context)
        {
            _context = context;
        }

    }  
}
