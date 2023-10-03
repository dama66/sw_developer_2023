using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenTypenGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int zahl;   //--> Deklaration

            zahl = 10;  //--> Initialisierung

            int counter = 3; //--> Deklaration + Initialisierung

            Console.WriteLine(zahl);
            Console.WriteLine(counter);
            Console.WriteLine("Counter; " + counter + " Min: " + int.MinValue + " Max: " + int.MaxValue);
           
            bool isPowerOn = false;

            Console.WriteLine("Power State: " + isPowerOn);
            Console.WriteLine($"Power State: {isPowerOn}");

            string name = "Hubert";

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Länge: {name.Length}");

            name = "";              //--> leerer string
            name = string.Empty;    //--> leerer string --> stanard

            double weight = 75.2345;

            Console.WriteLine($"Gewicht: {weight} kg");

            decimal salary = 12345.33984m;

            Console.WriteLine($"Gehalt: {salary} €");
        }
    }
}
