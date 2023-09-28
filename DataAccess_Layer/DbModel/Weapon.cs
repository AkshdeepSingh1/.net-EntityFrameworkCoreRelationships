using System;
using System.Text.Json.Serialization;

namespace EfCoreRelationships.DbModel
{
	public class Weapon
	{
		public int Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int CharacterId { get; set; }
        //navigational Properties
        [JsonIgnore]
        public Character Character { get; set; }
    }
}

