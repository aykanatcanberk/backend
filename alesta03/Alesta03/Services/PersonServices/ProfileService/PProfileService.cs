using Alesta03.Request.UpdateRequest;
using Alesta03.Response.UpdateResponse;

namespace Alesta03.Services.PersonServices.ProfileService
{
    public class PProfileService:IPProfileService
    {
        private readonly DataContext _context;

        public PProfileService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Person>> GetAllPeople()
        {
            var people = await _context.People.ToListAsync();
            return people;
        }

        public async Task<Person?> GetSinglePerson(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null)
                return null;

            return person;
        }

        public async Task<UpdatePProfileResponse?> UpdateProfile(int id, UpdatePProfileRequest request)
        {
            var model = await _context.People.FindAsync(id);

            if (model is null)
                return null;

            model.Name = request.Name;
            model.Surname = request.Surname;
            model.Birthday = request.Birthday;
            model.Phone = request.Phone;
            model.Location = request.Location;

            UpdatePProfileResponse response = new UpdatePProfileResponse();

            response.Name = model.Name;
            response.Surname = model.Surname;
            response.Birthday = model.Birthday;
            response.Phone = model.Phone;
            response.Location = model.Location;
            response.UpdateDate = model.UpdateDate;

            await _context.SaveChangesAsync();

            return response;
        }
    }
}
