using System;
using BuisnessLogic_Layer.Services;
using EfCoreRelationships.DbModel;
using EfCoreRelationships.Model;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreRelationships.Controllers
{
	[Route("api/[Controller]")]
	[ApiController]
	public class WeaponController:ControllerBase
	{
		private WeaponService weaponService;
		public WeaponController(WeaponService weaponService)
		{
			this.weaponService = weaponService;
		}

		[HttpGet]
		public async Task<ActionResult<Weapon>> getWeaponByCharacterId(int characterId)
		{
			var data = weaponService.getWeaponByCharacterId(characterId);
            return Ok(data);
		}

		[HttpPost]
		public async Task<ActionResult<Weapon>> addWeapons(WeaponDTO weaponDto)
		{
			var data = weaponService.addWeapons(weaponDto);
			return Ok(data);
		}
	}
}

