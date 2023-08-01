namespace Alesta03.Request.UpdateRequest
{
    public class UpdateInfoWorkRequest
    {
        public string CompanyName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string EmployeeID { get; set; }
        public string AppLetter { get; set; }
        public string CompanyEmail { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
    }
}
