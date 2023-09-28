using System;
using BuisnessLogic_Layer.Services;
using EfCoreRelationships.DbModel;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreRelationships.Controllers
{
	[Route("api/[Controller]")]
	[ApiController]
	public class SkillController: ControllerBase
	{
		private SkillService skillService;
		public SkillController(SkillService skillService)
		{
			this.skillService = skillService;
		}

		[HttpGet]
		public async Task<ActionResult<List<Skill>>> getSkills()
		{
			var data = await skillService.getSkills();
            return Ok(data);
		}
	}
}

