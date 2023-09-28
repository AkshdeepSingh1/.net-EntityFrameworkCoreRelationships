using System;
using DataAccess_Layer.DbModel;
using DataAccess_Layer.Interfaces;
using EfCoreRelationships.Data;
using EfCoreRelationships.DbModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess_Layer.Repositories
{
	public class CharacterRepository : ICharacterRepository
    {
        private DataContext context;
        public CharacterRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Character>> getCharachterMappedToUser(int userId)
        {
            //var data = await context.Characters.Where(w => w.UserId == userId).Select(s => new CharacterDTO
            //{
            //    id = s.id,
            //    Name = s.Name,
            //    RpgClass = s.RpgClass,
            //    UserId = s.UserId,
            //    Weapon = s.Weapon
            //}).ToListAsync();

            var data = await context.Characters.Where(w => w.UserId == userId)
                .Include(i => i.Weapon)
                .Include(i => i.Skills)
                .ToListAsync();
            return data;
        }

        public async Task<Character> getCharacterById(int characterId)
        {
            var data = await context.Characters.Where(w => w.id == characterId)
                .Include(i => i.User)
                .Include(i => i.Skills)
                .Include(i => i.Weapon)
                .FirstOrDefaultAsync();
            return data;
        }
        public async Task<List<Skill>> getCharachterSkillsByCharacterId(int characterId)
        {
            var data = await context.Characters.Where(w => w.id == characterId)
                .Include(i => i.Skills).FirstOrDefaultAsync();
            var data2 =  data?.Skills;
            return data2;
        }

        public async Task<Weapon> getCharachterWeaponByCharacterId(int characterId)
        {
            var data = await context.Characters.Where(w => w.id == characterId)
                .Include(i => i.Weapon).FirstOrDefaultAsync();
            var data2 = data?.Weapon;
            return data2;
        }

        public async Task<Character> addCharachter(Character characterToBeAdded)
        {

            context.Characters.Add(characterToBeAdded);
            await context.SaveChangesAsync();

            var latestCharacter = await context.Characters.Include(i => i.Skills).OrderByDescending(i => i.id).FirstOrDefaultAsync();
            return latestCharacter;
        }

        public async Task<Character> updateCharachter(Character updatedCharacter)
        {
            var characterToBeUpdated = await getCharacterById(updatedCharacter.id);

            characterToBeUpdated.UserId = updatedCharacter.UserId;
            characterToBeUpdated.Name = updatedCharacter.Name;
            characterToBeUpdated.RpgClass = updatedCharacter.RpgClass;
            characterToBeUpdated.id = updatedCharacter.id;

            await context.SaveChangesAsync();
            var dataToBeReturned = await getCharacterById(updatedCharacter.id);
            return dataToBeReturned;
        }
    }
}

