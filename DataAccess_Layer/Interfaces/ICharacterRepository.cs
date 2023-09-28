using System;
using EfCoreRelationships.DbModel;

namespace DataAccess_Layer.Interfaces
{
	public interface ICharacterRepository
	{
        Task<List<Character>> getCharachterMappedToUser(int userId);
        Task<Character> getCharacterById(int characterId);
        Task<List<Skill>> getCharachterSkillsByCharacterId(int characterId);
        Task<Weapon> getCharachterWeaponByCharacterId(int characterId);
        Task<Character> addCharachter(Character characterToBeAdded);
        Task<Character> updateCharachter(Character characterToBeUpdated);
    }
}

