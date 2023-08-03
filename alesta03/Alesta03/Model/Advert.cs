using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Alesta03.Model
{
    public class Advert
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string? CompanyName { get; set; }
        public string? AdvertName { get; set; }
        public DateTime? AdvertDate { get; set; }
        public string? Description { get; set; }
        public string? AdvertType { get; set; }
        public string? Department { get; set; }
        public string? WorkType { get; set; }
        public string? WorkPreference { get; set; }
        public bool IsDeleted { get; set; }

        public User User { get; set; }
        public int? UserId { get; set; }

        public List<AdvertApproval> AdvertApprovals { get; set; }

    }
}
