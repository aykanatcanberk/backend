namespace Alesta03.Model
{
    public class Approval
    {
        public int ID { get; set; }
        public string ApprovalStatus { get; set; } = "bekliyor";
        //bekliyor olanların listesinden
        //reddedildi 
        //onaylandı
        //sadece bekliyor olanlar gelecek

        public int BackWorkId { get; set; }
        public BackWork BackWork { get; set; }
    }
}
