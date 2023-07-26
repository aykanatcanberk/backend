namespace Alesta03.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string UserType { get; set; }

        public List<Company> companies { get; set; }
        public List<Person> people { get; set; }

        public Roles roles { get; set; }
        public string rolesId { get; set; }
    }
}
