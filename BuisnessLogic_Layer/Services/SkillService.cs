using System;
using DataAccess_Layer.Interfaces;
using EfCoreRelationships.DbModel;
using Microsoft.EntityFrameworkCore;

namespace BuisnessLogic_Layer.Services
{
	public class SkillService
	{
        private readonly ISkillRepository skillRepository;
        public SkillService(ISkillRepository skillRepository)
		{
            this.skillRepository = skillRepository;
        }

        public async Task<List<Skill>> getSkills()
        {
            var data = await skillRepository.getSkills();
            return data;
        }
    }
}

