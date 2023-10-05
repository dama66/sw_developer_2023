using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorenGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Arrithmetische Operatoren
            // + - / * %

            double flaecheRechteck = 0.0;
            double seiteA = 0.0;
            double seiteB = 0.0;

            flaecheRechteck = (seiteA + seiteB) * 2;

            //zusammengesetzte Operatoren

            seiteA = 5.0;

            seiteA = seiteA + 3;
            seiteA += 3;
            seiteA -= 3;
            seiteA *= 3;
            seiteA /= 3;

            //Inkrementieren/Dekrementieren
            seiteA = seiteA + 1;
            seiteA += 1;
            seiteA++; //--> (Post) Inkrement
            seiteA--; //--> (Post) Dekrement

            //Pre- und Post-Inkrement
            seiteA = 3;
            Console.WriteLine($"Seite A: {seiteA++}"); // = 3
            Console.WriteLine($"Seite A: {seiteA}");   // = 4
            Console.WriteLine($"Seite A: {++seiteA}"); // = 5

            //Vergleichsoperatoren
            // == != >= <= > <

            Console.WriteLine($"Ergebnis: {seiteA > 5.0}");

            string name = "Gandalf";

            Console.WriteLine($"Ist Alf:{name.Contains("alf")}");

            // Logische Operatoren
            // & | ! && ||

        }
    }
}
