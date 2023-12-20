using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursverwaltung.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Vorname { get; set; } = null!;
        public DateOnly Geburtsdatum { get; set; }
        public string Strasse {  get; set; }
        public string PLZ { get; set; }
        public string Ort { get; set; }
        public string Land { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }


    }
}
