using System;
using System.Text.Json.Serialization;

namespace EfCoreRelationships.DbModel
{
	public class User
	{
		public int id { get; set; }
		public string Name { get; set; } = string.Empty;
		//navigational properties
        public virtual List<Character> Characters { get; set; }

	}
}

