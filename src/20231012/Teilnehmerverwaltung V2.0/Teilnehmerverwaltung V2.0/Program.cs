using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teilnehmerverwaltung_V2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variable deklaration
            int xTitelPos = 0;
            var vorname = string.Empty;
            var name = string.Empty;
            var strGeburtsdatum = string.Empty;
            var geburtsdatum = new DateTime();
            var inputIsValid = false;

            Console.Clear();

            //Program Header
            string titel = "  Teilnehmer Verwaltung  ";
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));

            //cursor position for title
            xTitelPos = (Console.WindowWidth - titel.Length) / 2;
            Console.SetCursorPosition(xTitelPos, 1);
            Console.Write(titel);

            //reset cursor position
            Console.SetCursorPosition(0, 4);
            //set console title
            Console.Title = titel;


            //Eingabe der Daten
            Console.WriteLine("Bitte Teilnehmerdaten eingeben:");

            Console.Write("Vorname:                   ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            vorname = Console.ReadLine();
            Console.ResetColor();

            Console.Write("Namen:                     ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            name = Console.ReadLine();
            Console.ResetColor();

            do
            {
                Console.Write("Geburtsdatum: (dd.mm.yyyy) ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                strGeburtsdatum = Console.ReadLine();
                Console.ResetColor();

                try
                {
                    geburtsdatum = DateTime.ParseExact(strGeburtsdatum, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    inputIsValid = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\aERROR: Ungültige Datumseigabe.");
                    geburtsdatum = DateTime.MinValue;
                    Console.ResetColor();
                    inputIsValid = false;
                }
            }
            while (!inputIsValid);

            if (geburtsdatum.Year == DateTime.MinValue.Year)
            {
                return;
            }

            //Validierung der Daten
            TimeSpan alter = DateTime.Now.Subtract(geburtsdatum);

            if (alter <= TimeSpan.FromDays(16 * 365))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Du bist leider zu jung ;)");
                Console.ResetColor();
                return;
            }
            else if (alter >= TimeSpan.FromDays(95 * 365))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Du bist leider zu alt :P");
                return;
                Console.ResetColor();
            }
            else
            {
                //Ausgabe der Daten
                Console.Clear();
                Console.Write($"\n\n\tName:\t\t");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{name}");
                Console.ResetColor();
                Console.Write($"\n\tVorname:\t");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{vorname}");
                Console.ResetColor();
                Console.Write($"\n\tGeburtsdatum:\t");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{geburtsdatum.ToLongDateString()}\n");
                Console.ResetColor();
            }
        }
    }
}