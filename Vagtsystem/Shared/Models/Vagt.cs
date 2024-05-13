using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vagtsystem.Shared.Models
{
    public class Vagt
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Vagt_id { get; set; }
        public int Frivillig_vagt_id { get; set; }
        public int Frivillig_id { get; set; }
        public string? Navn { get; set; }
        public DateTime Start { get; set; } = new DateTime(2023,07,19);
        public DateTime Slut { get; set; } = new DateTime(2023, 07, 19);
        public int Hold_id { get; set; }
        public string? Holdnavn { get; set; }
        public int Prioritet { get; set; }
        public int Antal { get; set; }
    }
}
