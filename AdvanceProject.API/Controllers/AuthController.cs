using AdvanceProject.Bll.Abstract;
using AdvanceProject.Dto.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvanceProject.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthManager _authManager;
		public AuthController(IAuthManager authManager)
		{
			_authManager = authManager;
		}

		[HttpPost("~/api/register")]
		public IActionResult Register([FromBody]EmployeeRegisterDTO dto,string password)
		{
			var data = _authManager.Register(dto, password);
			if (data.Result.Data!=null)
			{
				return Ok(data.Result.Data);
			}
			return BadRequest(data.Result.Message);
		}
	}
}
