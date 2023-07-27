using Alesta03.Request.DtoRequest;
using Alesta03.Request.RgeisterRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Alesta03.Controllers.GeneralController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        public static Company company = new Company();
        public static Person person = new Person();
        public static RegisterRequestUC RegisterRequest { get; set; }

        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost("registerCompany")]
        public ActionResult<User> RegisterCompany(RegisterRequestUC request)
        {
            string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(request.UserDto.Password);

            company.Name = request.CompanyDto.Name;
                      
            user.Email = request.UserDto.Email;
            user.UserType = request.UserDto.UserType;
            user.PasswordHash = passwordHash;

            return Ok(user);
        }
        [HttpPost("registerPerson")]
        public ActionResult<User> RegisterPerson(RegisterRequestUP request)
        {
            string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(request.UserDto.Password);


            person.Name = request.PersonDto.Name;
            person.Surname = request.PersonDto.Surname;

            user.Email = request.UserDto.Email;
            user.UserType = request.UserDto.UserType;
            user.PasswordHash = passwordHash;

            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserDto request)
        {
            if (user.Email != request.Email)
            {
                return BadRequest("Kullanıcı Bulunamadı!");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Yanlış Şifre!");
            }
            if (user.UserType != request.UserType)
            {
                return BadRequest("Kullanıcı Türünüz Yanlış!");
            }

            string token = CreateToken(user);

            return Ok(token);
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
