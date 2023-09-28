using System;
using EfCoreRelationships.DbModel;

namespace DataAccess_Layer.Interfaces
{
	public interface IWeaponRepository
	{
        Task<Weapon> getWeaponByCharacterId(int characterId);
        Task<Weapon> addWeapons(Weapon weaponDto);
    }
}

