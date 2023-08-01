using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Alesta03.Model
{
    public class BackWork
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeID { get; set; }  
        public string AppLetter { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }

        public Approval Approval { get; set; }
        public List<WorkStatus> WorkStatuses { get; set; }

        public int ?companyID { get; set; }
        public Company company { get; set; }

    }
}
