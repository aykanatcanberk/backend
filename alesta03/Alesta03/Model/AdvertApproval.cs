using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Alesta03.Model
{
    public class AdvertApproval
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        

        public string? AppName { get; set; }
        public string? AppSurname { get; set; }
        public string? AppSchool { get; set; }
        public float AppAvg { get; set; }
        public string ?Status { get; set; } = "Henüz başvuru yapılmadı.";
        public DateTime ApproveDate { get; set; }
        public bool IsDeleted { get; set; } 

        public User Users { get; set; }
        public int? UserId { get; set; }

        public Advert Advert { get; set; }
        public int? AdvertId { get; set; }

        public Person Persons { get; set; }
        public int? PersonId { get; set; }

    }
}
