namespace Alesta03.Model
{
    public class BackEdu
    {
        public int ID { get; set; }
        public string SchoolName { get; set; }
        public string DepartmentName { get; set; }
        public string SchoolType { get; set; }
        public bool EduStatus { get; set; }
        public float Avg { get; set; }
        public DateTime UpdateDate { get; set; }
        public Company Company { get; set; }
        public string CompanyId { get; set; }
        public List<EduStatus> EduStatuses { get; set; }
       
    }
}
