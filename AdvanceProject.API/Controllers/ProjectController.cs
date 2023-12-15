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
	public class ProjectController : ControllerBase
	{
		private readonly IProjectManager _projectManager;

		public ProjectController(IProjectManager projectManager)
		{
			_projectManager = projectManager;

		}
		[HttpGet("~/api/getproject")]
		public IActionResult GetTitle()
		{
			var data = _projectManager.GetAll();
			if (data.Result.Data != null)
			{
				return Ok(data.Result.Data);
			}
			return BadRequest(data.Result.Message);
		}
	}
}
