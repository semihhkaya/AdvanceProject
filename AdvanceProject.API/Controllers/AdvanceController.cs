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

	}
}
