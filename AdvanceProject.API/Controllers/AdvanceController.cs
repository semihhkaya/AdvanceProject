using AdvanceProject.API.Contract.Request;
using AdvanceProject.Bll.Abstract;
using AdvanceProject.Dto.Advance;
using Microsoft.AspNetCore.Mvc;
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

		[HttpGet("~/api/getadvanceconfirmbyemployee")]
		public async Task<IActionResult> GetAdvanceConfirmByEmployee([FromQuery] int employeeId)
		{
			var data = await _advanceManager.GetAdvanceConfirmEmployee(employeeId);
			if (data.Data != null)
			{
				return Ok(data.Data);
			}
			return BadRequest(data.Message);
		}

		[HttpGet("~/api/gettitleid")]
		public IActionResult GetTitleID([FromQuery] decimal advanceAmount)
		{
			var data = _advanceManager.GetTitleID(advanceAmount);
			if (data.Data == null)
			{
				return NotFound();
			}

			return Ok(data.Data);
		}


		[HttpPost("~/api/getadvanceorderconfirm")]
		public IActionResult GetAdvanceOrderConfirm([FromBody]GetAdvanceOrderConfirmRequestModel model)
		{

			var data = _advanceManager.GetAdvanceOrderConfirm(model.BusinessUnitId, model.Titles);
			if (!ModelState.IsValid)
			{
				return BadRequest(data.Message);
			}

			if (data.Data == null)
			{
				return NotFound();
			}

			return Ok(data.Data);
		}

		[HttpPost("~/api/getadvanceapproveemployee")]
		public IActionResult GetAdvanceApproveEmployee([FromBody]GetAdvanceApproveEmployeeRequestModel model)
		{

			var data = _advanceManager.GetAdvanceApproveEmployee(model.AdvanceId, model.Titles);
			if (!ModelState.IsValid)
			{
				return BadRequest(data.Message);
			}
			if (data.Data == null)
			{
				return NotFound();
			}

			return Ok(data.Data);
		}

		[HttpPost("~/api/addadvancehistoryapprove")]
		public async Task<IActionResult> AddAdvanceHistoryApprove(AdanceHistoryApproveDTO dto)
		{
			var data = await _advanceManager.AddAdvanceHistoryApprove(dto);
			if (!ModelState.IsValid)
			{
				return BadRequest(data.Message);
			}
			if (data.Data == null)
			{
				return NotFound();
			}

			return Ok(data.Data);
		}

	}
}
