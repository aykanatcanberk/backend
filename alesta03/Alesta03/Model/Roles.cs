namespace Alesta03.Model
{
    public class Roles
    {
        public int ID { get; set; }

        public const string Admin = "Company";
        public const string User = "Person";

        public List<User> users { get; set; }
    }
}
