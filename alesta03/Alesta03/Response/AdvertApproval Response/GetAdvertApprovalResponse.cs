namespace Alesta03.Response.AdvertApproval_Response
{
    public class GetAdvertApprovalResponse
    {
        public int ApprovalId { get; set; }
        public int PersonId { get; set; }
        public int AdvertId { get; set; }
        public string Status { get; set; }
        public DateTime ApproveDate { get; set; }
    }
}
