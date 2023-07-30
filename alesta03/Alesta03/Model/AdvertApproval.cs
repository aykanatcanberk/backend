using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Alesta03.Model
{
    public class AdvertApproval
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public int PersonId { get; set; }
        public int AdvertId { get; set; }
        public string ?Status { get; set; } = "Henüz başvuru yapılmadı.";
        public DateTime ApproveDate { get; set; }
        public bool IsDeleted { get; set; }

        public Person person { get; set; } 
        
        public Advert Advert { get; set; }

    }
}
