using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kursverwaltung.Models
{
    public class Personen_Kurs
    {
        public long Id { get; set; }
        public long KursId { get; set; }
        public long PersonId { get; set; }
        public bool IstKursleiter { get; set; }

        public Kurs Kurs { get; set; } = null!;
        public Person Person { get; set; } = null!;


    }
}
