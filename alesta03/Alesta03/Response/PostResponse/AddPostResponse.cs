namespace Alesta03.Response.PostResponse
{
    public class AddPostResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset PostDate { get; set; }
        public string Content { get; set; }
    }
}
