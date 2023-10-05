using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EingabenGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Rechtecksberechnung
            // Umfang und Fläche berechnen 
            //************************************************************

            //Variablendeklaration & Initialisierung
            double seiteA = 10.5;
            double seiteB = 5.1;
            double flaeche = 0.0;
            double umfang = 0.0;
            int xTitlePos = 0;

            Console.Clear();

            //Darstellung Programmheader
            string title = "  Rechtecksberechnung V1.0  ";
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            xTitlePos = (Console.WindowWidth - title.Length) / 2;

            // cursor für Titel Ausgabe positionieren
            xTitlePos = (Console.WindowWidth - title.Length) / 2;
            Console.SetCursorPosition(xTitlePos, 1);
            Console.WriteLine(title);

            //alte cursorposition wiederherstellen
            Console.SetCursorPosition(0, 4);
            //Console Fensterbezeichnung setzen
            Console.Title = title;

            //Berechnung
            umfang = (seiteA + seiteB) * 2;
            flaeche = seiteA * seiteB;

            //Ausgabe
            Console.WriteLine("Ergebnis der Rechtecksberechnung...");
            Console.WriteLine($"\tUmfang: {umfang:f2}mm");
            Console.WriteLine($"\tFläche: {flaeche:f2}mm2\n");
        }
    }
}
