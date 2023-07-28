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

        public List<ExpReviews> Reviews { get; set; }
        public User User { get; set; }
        public List<Advert> Adverts { get; set; }

    }
}
