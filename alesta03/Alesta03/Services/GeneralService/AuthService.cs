using Alesta03.Model;
using Alesta03.Request.DtoRequest;
using Alesta03.Request.RgeisterRequest;
using Alesta03.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Alesta03.Services.GeneralService
{
    public class AuthService:IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ActionResult<User>> RegisterCompany(RegisterRequestUC request)
        {
            if (_context.Users.Any(u => u.Email == request.UserDto.Email))
                return null;
            
           string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(request.UserDto.Password);

            Company company = new Company();
            User user = new User();

            company.Name = request.CompanyDto.Name;

            user.Email = request.UserDto.Email;
            user.UserType = "Company";
            user.PasswordHash = passwordHash;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;

        }

        public async Task<ActionResult<User>> RegisterPerson(RegisterRequestUP request)
        {
            if (_context.Users.Any(u => u.Email == request.UserDto.Email))
                return null;

            string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(request.UserDto.Password);

            Person person = new Person();
            User user = new User();


            person.Name = request.PersonDto.Name;
            person.Surname = request.PersonDto.Surname;

            user.Email = request.UserDto.Email;
            user.UserType = "Person";
            user.PasswordHash = passwordHash;

            _context.Users.Add(user);   
            await _context.SaveChangesAsync();

            return user;

        }

        public async Task<ActionResult<string>> LoginPerson(UserDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            string control = user.UserType;

            if (control is "Company") 
                return null;
            if (user.Email != request.Email) 
                return null;
            else if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash)) 
                return null;
            else if (user.UserType != user.UserType) 
                return null;
            
            string token = CreateToken(user);
            await _context.SaveChangesAsync();

            LoginResult loginResult = new LoginResult
            {
                token = token,
                control = user.IsFirstLogin
            };

            string json = JsonConvert.SerializeObject(loginResult); 
            return json;
        }


        public async Task<ActionResult<string>> LoginCompany(UserDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            string control = user.UserType;

            if (control is "Person")
                return null;
            if (user.Email != request.Email)
                return null;
            else if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return null;
            else if (user.UserType != user.UserType)
                return null;

            string token = CreateToken(user);
            await _context.SaveChangesAsync();

            LoginResult loginResult = new LoginResult
            {
                token = token,
                control = user.IsFirstLogin
            };

            string json = JsonConvert.SerializeObject(loginResult);
            return json;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role,user.UserType)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
