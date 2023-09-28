using System.Formats.Asn1;
using BuisnessLogic_Layer.Services;
using DataAccess_Layer.DbModel;
using EfCoreRelationships.DbModel;
using EfCoreRelationships.Model;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreRelationships.Controllers
{
	[Route("api/Character")]
	[ApiController]
	public class CharacterController: ControllerBase
	{
        private CharacterService characterService;
        public CharacterController(CharacterService characterService)
        {
            this.characterService = characterService;
        }
        [HttpGet]
        [Route("getCharachterMappedToUser")]
        public async Task<ActionResult<List<Character>>> getCharachterMappedToUser(int userId)
        {
            var data = await characterService.getCharachterMappedToUser(userId);
            return Ok(data);
        }

        [HttpGet]
        [Route("getCharachterById")]
        public async Task<ActionResult<List<Character>>> getCharachterById(int characterId)
        {
            var data = await characterService.getCharachterById(characterId);
            return Ok(data);
        }

        [HttpGet]
        [Route("getCharachterSkillsByCharacterId")]
        public async Task<ActionResult<List<Skill>>> getCharachterSkillsByCharacterId(int characterId)
        {
            var data = await characterService.getCharachterSkillsByCharacterId(characterId);
            return Ok(data);
        }

        [HttpGet]
        [Route("getCharachterWeaponByCharacterId")]
        public async Task<ActionResult<List<Weapon>>> getCharachterWeaponByCharacterId(int characterId)
        {
            var data = await characterService.getCharachterWeaponByCharacterId(characterId);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<CharacterDTO>> addCharachter(CharacterDTO character)
        {
            if (character == null)
            {
                return BadRequest();
            }
            var data = await characterService.addCharachter(character);
            return Ok(data);
        }

        [HttpPost]
        [Route("addCharachtersSkill")]
        public async Task<ActionResult<List<Character>>> addCharachtersSkill(CharacterSkill result)
        {
            var data = characterService.addCharachtersSkill(result);
            return Ok();
        }

        [HttpPost]
        [Route("addFullCharacter")]
        public async Task<ActionResult<Character>> addFullCharacter(FullCharacterDTO result)
        {
            var data = characterService.addFullCharacter(result);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Character>> updateCharachter(CharacterDTO character)
        {
            if (character == null)
            {
                return BadRequest();
            }
            var data = characterService.updateCharachter(character);
            return Ok(data);
        }

    }
}

