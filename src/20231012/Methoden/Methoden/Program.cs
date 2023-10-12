using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methoden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteHelloWorld();

            WriteColoredMessage("Hallo....");
            WriteColoredMessage("Hier die Message...", ConsoleColor.DarkMagenta);

            int erg = Addition(15, 15);
            Console.WriteLine(erg);
        }

        //Signatur | Rückgabetyp | Methudenbezeichnung | (Parameterliste)

        //Methode ohne Parameter
        static void WriteHelloWorld()
        {
            Console.WriteLine("Hello World!");
        }

        //Methode mit Parametern
        static void WriteColoredMessage(String message, ConsoleColor color)
        {
            ConsoleColor oldColour = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = oldColour;
        }

        //Methoden Überladung
        static void WriteColoredMessage(String message)
        {
            WriteColoredMessage(message, ConsoleColor.Yellow);
        }

        //Methode mit Parametern und Rückgabe
        static int Addition(int val1, int val2)
        {
            int summe = 0;
            summe = val1 + val2;
            return summe;
        }


    }
}
