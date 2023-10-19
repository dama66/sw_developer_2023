using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlagen_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int zahl = 4;
            const int MAX_ITEM_COUNT = 40;


            //Deklaration und Dimensionierung
            int[] zahlen = new int[MAX_ITEM_COUNT];

            //Initialisierung
            for (int i = 0; i < zahlen.Length; i++)
            {
                zahlen[i] = 0;
            }

            zahlen[0] = 45;
            zahlen[2] = 50;
             

            Console.WriteLine($"2. Wert: {zahlen[1]}");


        }
    }
}
