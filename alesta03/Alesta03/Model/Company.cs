namespace Alesta03.Model
{
    public class Company
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FDate { get; set; }
        public int TotalStaff { get; set; }
        public string Location { get; set; }

        public User users { get; set; }
        public string usersId { get; set; }

        public List<ExpReviews> reviews { get; set; }

    }
}
