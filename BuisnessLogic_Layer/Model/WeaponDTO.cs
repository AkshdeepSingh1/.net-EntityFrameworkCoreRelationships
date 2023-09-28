using System;
using EfCoreRelationships.DbModel;
using System.Text.Json.Serialization;

namespace EfCoreRelationships.Model
{
	public class WeaponDTO
	{
		
        public string Name { get; set; }
        public int Damage { get; set; }
        public int CharacterId { get; set; }
   
	}
}

