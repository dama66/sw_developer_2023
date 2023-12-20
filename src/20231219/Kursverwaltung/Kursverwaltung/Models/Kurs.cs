using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursverwaltung.Models
{
    public class Kurs
    {
        public long Id { get; set; }

        public string Bezeichnung { get; set; } = null!;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preis {  get; set; }

    }
}
