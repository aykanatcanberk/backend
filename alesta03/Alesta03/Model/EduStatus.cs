namespace Alesta03.Model
{
    public class EduStatus
    {
        public int ID { get; set; }

        public Person Person { get; set; }
        public string PersonId { get; set; }

        public BackEdu BackEdu { get; set; }
        public string BackEduId { get; set; }
    }
}
