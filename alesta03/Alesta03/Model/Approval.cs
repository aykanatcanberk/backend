using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alesta03.Model
{
    public class Approval
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string ApprovalStatus { get; set; } = String.Empty;
        //r--> red yedi
        //o--> onaylandı
        //b--> bekliyor
        public int ?BackWorkId { get; set; }
        public BackWork BackWork { get; set; }
                
    }
}
