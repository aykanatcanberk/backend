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
        public string DepartmentName { get; set; }
        public int EmployeeID { get; set; }
        public string AppLetter { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public DateTime UpdateDate { get; set; }

        public Approval Approval { get; set; }
        public List<WorkStatus> WorkStatuses { get; set; }
    }
}
