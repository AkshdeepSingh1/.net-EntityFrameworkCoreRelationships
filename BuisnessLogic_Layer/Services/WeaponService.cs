using System;
using DataAccess_Layer.Interfaces;
using EfCoreRelationships.DbModel;
using EfCoreRelationships.Model;
using Microsoft.EntityFrameworkCore;

namespace BuisnessLogic_Layer.Services
{
	public class WeaponService 
	{
		private readonly IWeaponRepository weaponRepository;
        private readonly ICharacterRepository characterRepository;

        public WeaponService(IWeaponRepository weaponRepository, ICharacterRepository characterRepository)
		{
			this.weaponRepository = weaponRepository;
            this.characterRepository = characterRepository;
        }

        public async Task<Weapon> getWeaponByCharacterId(int characterId)
        {
            var weapon = await weaponRepository.getWeaponByCharacterId(characterId);
            return weapon;
        }

        public async Task<Weapon> addWeapons(WeaponDTO weaponDto)
        {
            var oldcharacter = await characterRepository.getCharacterById(weaponDto.CharacterId);

            if (oldcharacter != null)
            {
                var weaponToBeAdded = new Weapon
                {
                    Name = weaponDto.Name,
                    Damage = weaponDto.Damage,
                    CharacterId = weaponDto.CharacterId,
                };

                var weaponAdded = await weaponRepository.addWeapons(weaponToBeAdded);
                return weaponAdded;
            }
            else
            {
                return new Weapon();
            }
        }

    }
}

