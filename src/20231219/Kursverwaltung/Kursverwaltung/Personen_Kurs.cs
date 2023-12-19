using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kursverwaltung
{
    public class Personen_Kurs
    {
        public long Id;
        public long KursId = Kurs1.Id;
        public long PersonenId = Person.Id;
        public bool IstKursleiter;

        Kurs1 = new Kurs();

    }
}
