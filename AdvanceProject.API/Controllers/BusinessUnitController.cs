using AdvanceProject.Bll.Abstract;
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
	public class BusinessUnitController : ControllerBase
	{
		private readonly IBusinessUnitManager _businessUnitManager;

		public BusinessUnitController(IBusinessUnitManager businessUnitManager)
		{
			_businessUnitManager = businessUnitManager;

		}

		[HttpGet("~/api/getbusinessunit")]
		public IActionResult GetBusinessUnit()
		{
			var data = _businessUnitManager.GetAll();
			if (data.Result.Data != null)
			{
				return Ok(data.Result.Data);
			}
			return BadRequest(data.Result.Message);
		}
	}
}
