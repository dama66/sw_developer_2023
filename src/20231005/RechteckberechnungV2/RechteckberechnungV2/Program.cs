using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EingabenGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Rechtecksberechnung
            //Umfang & Fläche berechnen
            //*********************************************************

            //Variablen Deklaration & Initialisierung
            double seiteA = 0.0;
            double seiteB = 0.0;
            double flaeche = 0.0;
            double umfang = 0.0;
            int xTitelPos = 0;

            Console.Clear();

            //Darstellung Programm Header
            string titel = "  Rechtecksberechnung v1.0  ";
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));

            //cursor f. Titel Ausgabe positionieren
            xTitelPos = (Console.WindowWidth - titel.Length) / 2;
            Console.SetCursorPosition(xTitelPos, 1);
            Console.Write(titel);

            //alte cursor Position wiederherstellen
            Console.SetCursorPosition(0, 4);
            //Consolen Fensterbezeichnung setzen
            Console.Title = titel;

            //Eingaben
            Console.WriteLine("Rechteckdaten eingeben:");
            Console.Write("\tseite A:");
            seiteA = double.Parse(Console.ReadLine());

            Console.Write("\tseite B:");
            seiteB = double.Parse(Console.ReadLine());

            //Berechnung
            flaeche = seiteA * seiteB;
            umfang = (seiteA + seiteB) * 2;

            //Ausgabe der Ergebnisse
            Console.WriteLine("\nErgebnisse Rechtecksberechnung:");
            Console.WriteLine($"\tUmfang: {umfang:f2}");
            Console.WriteLine($"\tFläche: {flaeche:f2}");
            Console.WriteLine();
        }
    }
}
