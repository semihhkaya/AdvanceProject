using AdvanceProject.Bll.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceProject.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TitleController : ControllerBase
	{
		private readonly ITitleManager _titleManager;

		public TitleController(ITitleManager titleManager)
		{
			_titleManager = titleManager;

		}
		[HttpGet("~/api/gettitle")]
		public IActionResult GetTitle()
		{
			var data = _titleManager.GetAll();
			if (data.Result.Data != null)
			{
				return Ok(data.Result.Data);
			}
			return BadRequest(data.Result.Message);
		}
	}
}
