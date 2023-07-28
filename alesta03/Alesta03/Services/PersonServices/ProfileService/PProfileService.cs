using Alesta03.Request.UpdateRequest;
using Alesta03.Response.UpdateResponse;

namespace Alesta03.Services.PersonServices.ProfileService
{
    public class PProfileService:IPProfileService
    {
        private static List<Person> people = new List<Person>
            {
                new Person
                {
                    ID = 1,
                    Name = "Patrick",
                    Surname = "Bateman",
                    Birthday = new DateTime(1990,12,05),
                    Phone = "00000000",
                    Location = "Adana"
                },
                new Person
                {
                    ID = 2,
                    Name = "Merve",
                    Surname = "Bateman",
                    Birthday = new DateTime(1990,12,05),
                    Phone = "0000990",
                    Location = "Adana"
                }
        };

        public List<Person> GetAllPeople()
        {
            return people;
        }

        public Person? GetSinglePerson(int id)
        {
            var person = people.Find(x => x.ID == id);
            if (person == null)
                return null;

            return person;
        }

        public UpdatePProfileResponse? UpdateProfile(int id, UpdatePProfileRequest request)
        {
            Person model = new Person();

            model = people.Find(x => x.ID == id);

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

            return response;
        }
    }
}
