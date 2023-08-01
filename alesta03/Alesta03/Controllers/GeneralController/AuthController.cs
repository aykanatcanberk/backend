using Alesta03.Request.DtoRequest;
using Alesta03.Request.RgeisterRequest;
using Alesta03.Services.GeneralService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IAuthService _authService;
        private readonly DataContext _context;

        public AuthController(IConfiguration configuration,IAuthService authService, DataContext context)
        {
            _configuration = configuration;
            _authService = authService;
            _context = context;
        }


        [HttpPost("registerCompany")]
        public async Task<ActionResult<User>> RegisterCompany(RegisterRequestUC request)
        {
            if (_context.Users.Any(u => u.Email == request.UserDto.Email))
            {
                return BadRequest("E-Posta daha önce kaydedilmiş!");
            }
            var result = await _authService.RegisterCompany(request);
            return result;
        }
        [HttpPost("registerPerson")]
        public async Task<ActionResult<User>> RegisterPerson(RegisterRequestUP request)
        {
            if (_context.Users.Any(u => u.Email == request.UserDto.Email))
            {
                return BadRequest("E-Posta daha önce kaydedilmiş!");
            }
            var result = await _authService.RegisterPerson(request);
            return result;
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserDto request)
        {
            var user = _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            
            if (user.Result is null) 
            {
                return BadRequest("Kullanıcı  Bulunamadı!"); 
            }

            if (user is null)
            {
                return BadRequest("Kullanıcı  Bulunamadı!");
            }

            else if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Result.PasswordHash))
            {
                return BadRequest("Yanlış Şifre!");
            }
            else if (user.Result.UserType != user.Result.UserType)
            {
                return BadRequest("Kullanıcı Türünüz Yanlış!");
            }

            if(user.Result.IsFirstLogin is true)
                user.Result.IsFirstLogin = false;
                _context.SaveChanges();

            string token = CreateToken(user.Result);

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
