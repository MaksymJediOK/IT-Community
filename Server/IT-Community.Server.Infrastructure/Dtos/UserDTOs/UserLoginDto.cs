namespace IT_Community.Server.Infrastructure.Dtos.UserDTOs
{
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
