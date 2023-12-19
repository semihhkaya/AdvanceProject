using AdvanceProject.Bll.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceProject.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeManager _employeeManager;

		public EmployeeController(IEmployeeManager employeeManager)
		{
			_employeeManager = employeeManager;

		}

		[HttpGet("~/api/getemployee")]
		public IActionResult GetBusinessUnit()
		{
			var data = _employeeManager.GetAll();
			if (data.Result.Data != null)
			{
				return Ok(data.Result.Data);
			}
			return BadRequest(data.Result.Message);
		}
	}
}
