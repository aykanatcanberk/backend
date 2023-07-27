namespace Alesta03.Request.UpdateRequest
{
    public class UpdateInfoWorkRequest
    {
        public string CompanyName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; } = DateTime.Now;
    }
}
