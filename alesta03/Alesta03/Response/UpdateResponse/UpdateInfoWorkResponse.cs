namespace Alesta03.Response.UpdateResponse
{
    public class UpdateInfoWorkResponse
    {
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
