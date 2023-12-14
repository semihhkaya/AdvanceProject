using AdvanceProject.API.Filters;
using AdvanceProject.Bll.Abstract;
using AdvanceProject.Dto.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthManager _authManager;
		private readonly IConfiguration _configuration;
		public AuthController(IAuthManager authManager,IConfiguration configuration)
		{
			_authManager = authManager;
			_configuration = configuration;
		}

		[EmailUniqueCheckAttribute]
		[HttpPost("~/api/register")]
		public IActionResult Register([FromBody]EmployeeRegisterDTO dto)
		{
			var data = _authManager.Register(dto, dto.Password);
			if (data.Result.Data!=null)
			{
				return Ok(data.Result.Data);
			}
			return BadRequest(data.Result.Message);
		}

		[HttpPost("~/api/login")]
		public IActionResult Login([FromBody] EmployeeLoginDTO dto)
		{
			var data = _authManager.Login(dto);
			if (data.Result.Data != null)
			{
				var token = GenerateJwtToken(data.Result.Data.Name); // Kullanıcı adını tokena ekleyin
				return Ok(new { User = data.Result.Data, Token = token });
			}

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
				Expires = DateTime.Now.AddMinutes(20),
				Subject = new ClaimsIdentity(new Claim[] {
			new Claim(ClaimTypes.Name, userName)
		}),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
