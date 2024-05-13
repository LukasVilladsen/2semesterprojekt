using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vagtsystem.Shared.Models
{ 
    public class Frivillig
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Frivillig_id { get; set; }
        public string? Fornavn { get; set; }
        public string? Efternavn { get; set; }
        public string? Navn { get; set; }
        public int Telefon { get; set; }
        public string? Email { get; set; }
        public string? Adresse { get; set; }
        public DateTime Fødselsdag { get; set; } = DateTime.Now;
        public int Hold_id { get; set; }
        public int Stilling_id { get; set; }
        public string? Holdnavn { get; set; }
        public string? Stillingnavn { get; set; }
    }
}
