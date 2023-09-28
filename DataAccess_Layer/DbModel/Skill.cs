using System;
using System.Text.Json.Serialization;

namespace EfCoreRelationships.DbModel
{
	public class Skill
	{
		public int id { get; set; }
		public string Name { get; set; } = string.Empty;
		public int Damage { get; set; }
        [JsonIgnore]
        public List<Character> Characters { get; set; }
    }
}

