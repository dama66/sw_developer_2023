using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbfragenGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int zahl = 5;

            if (zahl >= 5)
            {
                Console.WriteLine("Die Zahl ist grösser/gleich 5.");

                //...
                //..
                //.
            }
            else
            { 
                Console.WriteLine("Die Zahl ist kleiner 5.");
            }

            //Werte zwischen 3..5

            if (zahl > 3 && zahl < 5)
            {
            Console.WriteLine("Die Zahl liegt im gültigen Bereich.");
            }
            Console.WriteLine("ENDE");

           

        }
    }
}
