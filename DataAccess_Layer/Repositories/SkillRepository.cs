using System;
using DataAccess_Layer.Interfaces;
using EfCoreRelationships.Data;
using EfCoreRelationships.DbModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess_Layer.Repositories
{
	public class SkillRepository : ISkillRepository
    {
        private DataContext context;
        public SkillRepository(DataContext context)
        {
            this.context = context;
        }
        public async Task<List<Skill>> getSkills()
        {
            var data = await context.Skills
                .ToListAsync();
            return data;
        }
        public async Task<Skill> getSkillBySkillId(int skillId)
        {
            var data = await context.Skills.Where(w => w.id == skillId)
                .FirstOrDefaultAsync();
            return data;
        }
        public async Task<List<Skill>> getSkillsBySkillIdList(List<int> skillIds)
        {
            var data = await context.Skills.
                Where(i => skillIds.Contains(i.id)).ToListAsync();
            return data;
        }
        public async Task AddSkillToCharacter(Character characterSeleted, Skill skillSelected)
        {
            characterSeleted.Skills.Add(skillSelected);
            await context.SaveChangesAsync();
        }
        public async Task AddSkillsToCharacter(Character characterSeleted, List<Skill> skillSelected)
        {
            characterSeleted.Skills.AddRange(skillSelected);
            await context.SaveChangesAsync();
        }
    }
}

