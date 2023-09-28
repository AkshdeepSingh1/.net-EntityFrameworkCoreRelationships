using System;
using EfCoreRelationships.DbModel;

namespace EfCoreRelationships.Model
{
	public class CharacterDTO
	{
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RpgClass { get; set; } = "Knight";
        public int UserId { get; set; }
    }

    public class FullCharacterDTO : CharacterDTO
    {
        public List<int> skillIds {get; set;}
        public string weaponName { get; set; }
        public int weaponDamage { get; set; }
    }
}

