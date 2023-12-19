using AdvanceProject.API.Contract.Request;
using AdvanceProject.Bll.Abstract;
using AdvanceProject.Dto.Advance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
		private readonly ILogger<AdvanceController> _logger;
		public AdvanceController(IAdvanceManager advanceManager, ILogger<AdvanceController> logger)
		{
			_advanceManager = advanceManager;
			_logger = logger;
		}

		[HttpPost("~/api/addadvance")]
		public async Task<IActionResult> AddAdvance(AdvanceInsertDTO advanceInsertDTO)
		{
			var data = await _advanceManager.AddAdvance(advanceInsertDTO);

			if (data==null)
			{
				_logger.LogError("Veri eklenirken hata oluştu");
			}

			_logger.LogInformation("Veri eklendi", data);

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
				_logger.LogError("Avans onaylanırken bir hata meydana geldi",ModelState);
				return BadRequest(data.Message);
			}
			
			var result  = await _advanceManager.GetAdvanceChangeStatus(dto.AdvanceID,dto.StatusID);
			if (result.Data)
			{
				return Ok(data.Data);
			}

			return BadRequest(data.Message);
		}

		[HttpGet("~/api/getuseradvancelist")]
		public async Task<IActionResult> GetUserAdvanceList(int employeeId, int businessUnitID)
		{
			var data = await _advanceManager.GetUserAdvanceList(employeeId,businessUnitID);
			if (data.Data == null)
			{
				return NotFound();
			}

			return Ok(data.Data);
		}

		[HttpGet("~/api/rejectadvance")]
		public async Task<IActionResult> RejectAdvance(int advanceId)
		{
			var data = await _advanceManager.GetAdvanceChangeStatus(advanceId,103);
			if (data.Data == false)
			{
				_logger.LogWarning("Avans reddi sırasında bir sorun oluştu");

				return BadRequest();
			}

			return Ok(data.Data);
		}

	}
}
