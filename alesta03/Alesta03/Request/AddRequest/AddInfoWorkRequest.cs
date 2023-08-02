namespace Alesta03.Request.AddRequest
{
    public class AddInfoWorkRequest
    {
        public string CompanyEmail { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string EmployeeID { get; set; }
        public string AppLetter { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
