using System;
using DataAccess_Layer.Interfaces;
using EfCoreRelationships.Data;
using EfCoreRelationships.DbModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess_Layer.Repositories
{
    public class WeaponRepository : IWeaponRepository
    {
        private DataContext context;
        public WeaponRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<Weapon> getWeaponByCharacterId(int characterId)
        {
            Weapon data = null;
            try
            {
                 data = await context.Weapons.Where(w => w.CharacterId == characterId).FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {

            }
            return data;
        }

        public async Task<Weapon> addWeapons(Weapon weaponToBeAdded)
        {
            await context.Weapons.AddAsync(weaponToBeAdded);
            await context.SaveChangesAsync();
            return weaponToBeAdded;
        }
    }
}