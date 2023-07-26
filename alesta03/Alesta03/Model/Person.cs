namespace Alesta03.Model
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }

        public User users { get; set; }
        public string usersId { get; set; }

        public ICollection<ExpReviews> reviews { get; set; }
    }
}
