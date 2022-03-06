using BikesKart.Helpers;
using BikesKart.Models;
using BikesKart.Models.Login;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;

namespace BikesKart.Services
{
    public interface IUserService
    {
        LoginResponse Login(LoginRequest request);
        IEnumerable<User> GetAll();
        User GetById(string id);

    }
    public class UsersService : IUserService
    {

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { Id = "1", Name = "Test", Email = "User@test.com", Password = "test" }
        };

        private readonly AppSettings _appSettings;
        public UsersService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(string id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public LoginResponse Login(LoginRequest request)
        {
            var user = _users.FirstOrDefault(x => x.Email == request.Email && x.Password == request.Password);

            if(user == null) return null;

            var token = GenerateJwtToken(user);

            return new LoginResponse(user, token);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
