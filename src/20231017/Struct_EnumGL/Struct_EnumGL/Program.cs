using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct_EnumGL
{
    public struct Teilnehmer
    {
        public string Name;
        public string Vorname;
        public DateTime Gebutsdatum;
        public int Plz;
        public string Ort;
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            //Deklaration
            Teilnehmer teilnehmer1;

            //Initialiserung
            teilnehmer1 = new Teilnehmer();

            //kombiliert
            Teilnehmer teilnehmer2 = new Teilnehmer();

            //Variablen initialiseren
            teilnehmer1.Name = String.Empty;
            teilnehmer1.Vorname = String.Empty;
            teilnehmer1.Gebutsdatum = DateTime.MinValue;
            teilnehmer1.Plz = 0;
            teilnehmer1.Ort = String.Empty;

            DisplayTeilnehmerData(teilnehmer1);
        }

        static Teilnehmer ReadData()
        {
            Teilnehmer teilnehmer3 = new Teilnehmer();

            return teilnehmer3;
        }

        private static void DisplayTeilnehmerData(Teilnehmer teilnehmer)
        {

        }
    }
}
