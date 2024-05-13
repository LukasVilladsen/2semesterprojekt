using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vagtsystem.Shared.Models
{
	public class Stilling
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Stilling_id { get; set; }
		public string Stillingnavn { get; set; }
	}
}

