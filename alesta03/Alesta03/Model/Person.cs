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
        public DateTime UpdateDate { get; set; }

        public User Users { get; set; }
        public string UsersId { get; set; }

        public List<ExpReviews> Reviews { get; set; }

        public List<EduStatus> EduStatuses { get; set; }
        public List<WorkStatus> WorkStatuses { get; set; }
    }
}
