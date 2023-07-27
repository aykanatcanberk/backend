namespace Alesta03.Model
{
    public class BackWork
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public DateTime UpdateDate { get; set; }
        public int ApprovalId { get; set; }
        public Approval Approval { get; set; }
        public List<WorkStatus> WorkStatuses { get; set; }
    }
}
