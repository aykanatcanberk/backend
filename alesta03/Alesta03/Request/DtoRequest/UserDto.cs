namespace Alesta03.Request.DtoRequest
{
    public class UserDto
    {
        public required string Email { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
        public required string UserType { get; set; } = string.Empty;
    }
}
