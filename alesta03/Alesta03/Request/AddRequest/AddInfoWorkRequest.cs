namespace Alesta03.Request.AddRequest
{
    public class AddInfoWorkRequest
    {
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyEmail { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string EmployeeID { get; set; }
        public string AppLetter { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
    }
}
