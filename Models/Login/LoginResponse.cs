namespace BikesKart.Models.Login
{
    public class LoginResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public LoginResponse(User user, string token)
        {
            Id = user.Id;
            Name = user.Name;   
            Email = user.Email;
            Token = token;
        }
    }
}
