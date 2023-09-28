using System;
using System.Text.Json.Serialization;

namespace EfCoreRelationships.DbModel
{
	public class Character
	{
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RpgClass { get; set; } = "Knight";
        
        public int UserId { get; set; }
        //navigational Properties
        [JsonIgnore]
        public User User { get; set; }
        public Weapon Weapon { get; set; }
        public List<Skill> Skills { get; set; }

    }
}

