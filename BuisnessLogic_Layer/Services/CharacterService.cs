using System;
using System.Formats.Asn1;
using DataAccess_Layer.DbModel;
using DataAccess_Layer.Interfaces;
using DataAccess_Layer.Repositories;
using EfCoreRelationships.DbModel;
using EfCoreRelationships.Model;
using Microsoft.EntityFrameworkCore;

namespace BuisnessLogic_Layer.Services
{
	public class CharacterService
	{
        private ICharacterRepository characterRepository;
        private ISkillRepository skillRepository;
        private IWeaponRepository weaponRepository;
        public CharacterService(ICharacterRepository characterRepository, ISkillRepository skillRepository, IWeaponRepository weaponRepository)
        {
            this.characterRepository = characterRepository;
            this.skillRepository = skillRepository;
            this.weaponRepository = weaponRepository;
        }

        public async Task<List<Character>> getCharachterMappedToUser(int userId)
        {
            var characters = await characterRepository.getCharachterMappedToUser(userId);
            return characters;
        }

        public async Task<Character> getCharachterById(int characterId)
        {
            var character = await characterRepository.getCharacterById(characterId);
            return character;
        }

        public async Task<List<Skill>> getCharachterSkillsByCharacterId(int characterId)
        {
            var skills = await characterRepository.getCharachterSkillsByCharacterId(characterId);
            return skills;
        }

        public async Task<Weapon> getCharachterWeaponByCharacterId(int characterId)
        {
            var weapon = await characterRepository.getCharachterWeaponByCharacterId(characterId);
            return weapon;
        }

        public async Task<CharacterDTO> addCharachter(CharacterDTO character)
        {
            Character characterToBeAdded = new Character();
            characterToBeAdded.UserId = character.UserId;
            characterToBeAdded.Name = character.Name;
            characterToBeAdded.RpgClass = character.RpgClass;


            var characterAdded = await characterRepository.addCharachter(characterToBeAdded);

            var characterDTOAdded = new CharacterDTO
            {
                id = characterAdded.id,
                Name = characterAdded.Name,
                RpgClass = characterAdded.RpgClass,
                UserId = characterAdded.UserId
            };

            return characterDTOAdded;
        }

        public async Task<Character> addCharachtersSkill(CharacterSkill result)
        {

            var characterSelected = await characterRepository.getCharacterById(result.CharacterId);
            
            var skillSelected = await skillRepository.getSkillBySkillId(result.SkillId);
           
            await skillRepository.AddSkillToCharacter(characterSelected, skillSelected);

            var characterToBeReturned = await characterRepository.getCharacterById(result.CharacterId);

            return characterToBeReturned;
        }

        public async Task<Character> addFullCharacter(FullCharacterDTO result)
        {
            // Adding character
            var character = new Character();
            character.Name = result.Name;
            character.RpgClass = result.RpgClass;
            character.UserId = result.UserId;

            var latestCharacter =  await characterRepository.addCharachter(character);

            //Adding Weapon To That Character
            var weapon = new Weapon();
            weapon.Name = result.weaponName;
            weapon.Damage = result.weaponDamage;
            weapon.CharacterId = latestCharacter.id;

            var weaponAdded = await weaponRepository.addWeapons(weapon);

            // Adding Skill To that character
            var skillsToBeAdded = await skillRepository.getSkillsBySkillIdList(result.skillIds);

            var characterToBeReturned = await characterRepository.getCharacterById(latestCharacter.id);

            return characterToBeReturned;
        }

        public async Task<Character> updateCharachter(CharacterDTO character)
        {
            Character updatedCharacter = new Character();
            updatedCharacter.UserId = character.UserId;
            updatedCharacter.Name = character.Name;
            updatedCharacter.RpgClass = character.RpgClass;
            updatedCharacter.id = character.id;

            var data = await characterRepository.updateCharachter(updatedCharacter);

            return data;
        }
    }
}

