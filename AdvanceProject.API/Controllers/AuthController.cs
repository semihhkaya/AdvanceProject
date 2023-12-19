using AdvanceProject.API.Filters;
using AdvanceProject.Bll.Abstract;
using AdvanceProject.Dto.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AdvanceProject.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthManager _authManager;
		private readonly IConfiguration _configuration;
		private readonly ILogger<AuthController> _logger;
		public AuthController(IAuthManager authManager, IConfiguration configuration,ILogger<AuthController> logger)
		{
			_authManager = authManager;
			_configuration = configuration;
			_logger = logger;
		}

		[EmailUniqueCheckAttribute]
		[HttpPost("~/api/register")]
		public IActionResult Register([FromBody] EmployeeRegisterDTO dto)
		{
			var data = _authManager.Register(dto, dto.Password);
			if (data.Result.Data != null)
			{
				_logger.LogInformation("Kullanıcı kaydedildi");
				return Ok(data.Result.Data);
			}
			_logger.LogInformation("Kullanıcı kaydedilirken bir hata meydana geldi", data);
			return BadRequest(data.Result.Message);
		}

		[HttpPost("~/api/login")]
		public IActionResult Login([FromBody] EmployeeLoginDTO dto)
		{
			var data = _authManager.Login(dto);
			if (data.Result.Data != null)
			{
				var token = GenerateJwtToken(data.Result.Data.Name);
				if (token!=null)
				{
					_logger.LogInformation("Token üretildi");
				}
				data.Result.Data.Token = token;

				_logger.LogInformation("Giriş başarılı");
				return Ok(data.Result.Data);
			}
			_logger.LogError("Giriş başarısız oldu", data.Result.Message);
			return BadRequest(data.Result.Message);
		}

		private string GenerateJwtToken(string userName)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.UTF8.GetBytes(_configuration["apisecretkey"]);

			var tokenDescriptor = new SecurityTokenDescriptor()
			{
				Audience = "BilgeAdam",
				Issuer = "Semih",
				Expires = DateTime.Now.AddMinutes(1),
				Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, userName) }),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}
	}
}
