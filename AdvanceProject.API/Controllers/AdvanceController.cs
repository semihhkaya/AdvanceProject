using AdvanceProject.Bll.Abstract;
using AdvanceProject.Dto.Advance;
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
	public class AdvanceController : ControllerBase
	{
		private IAdvanceManager _advanceManager;
		public AdvanceController(IAdvanceManager advanceManager)
		{
			_advanceManager = advanceManager;
		}

		[HttpPost("~/api/addadvance")]
		public async Task<IActionResult> AddAdvance(AdvanceInsertDTO advanceInsertDTO)
		{
			var data = await _advanceManager.AddAdvance(advanceInsertDTO);

			return Ok(data.Data);
		}

		[HttpGet("~/api/getadvancebyemployeeid")]
		public async Task<IActionResult> GetAdvanceByEmployeeId([FromQuery] int employeeId)
		{
			//var data = await _advanceManager.GetAdvanceByEmployeeId(employeeId);
			var data = _advanceManager.GetAdvanceListData(employeeId);

			List<EmployeeAdvanceResponseDto> result = new List<EmployeeAdvanceResponseDto>();
			foreach (var item in data.Data.ToList())
			{
				result.Add(item);
			}

			return Ok(result);
		}

		[HttpGet("~/api/getadvancedetails")]
		public async Task<IActionResult> GetAdvanceDetails([FromQuery] int advanceId)
		{
			//var data = await _advanceManager.GetAdvanceByEmployeeId(employeeId);
			var data = _advanceManager.GetAdvanceDetails(advanceId);

			List<AdvanceDetailDTO> result = new List<AdvanceDetailDTO>();
			foreach (var item in data.Data.ToList())
			{
				result.Add(item);
			}

			return Ok(result);
		}
	}
}
