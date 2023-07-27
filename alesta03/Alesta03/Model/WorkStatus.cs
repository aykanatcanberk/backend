namespace Alesta03.Model
{
    public class WorkStatus
    {
        public int ID { get; set; }

        public Person Person { get; set; }
        public string PersonId { get; set; }

        public BackWork BackWork { get; set; }
        public string BackWorkId { get; set; }
    }
}
