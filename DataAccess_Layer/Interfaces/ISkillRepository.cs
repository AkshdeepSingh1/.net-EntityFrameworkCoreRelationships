using System;
using EfCoreRelationships.DbModel;

namespace DataAccess_Layer.Interfaces
{
	public interface ISkillRepository
	{
        Task<List<Skill>> getSkills();
        Task<Skill> getSkillBySkillId(int skillId);
        Task<List<Skill>> getSkillsBySkillIdList(List<int> skillIds);
        Task AddSkillToCharacter(Character characterSeleted, Skill skillSelected);
        Task AddSkillsToCharacter(Character characterSeleted, List<Skill> skillSelected);
    }
}

