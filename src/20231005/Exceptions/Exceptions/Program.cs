using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int alter = 0;

Eingabe:
            Console.Write("Alter eingeben:");

            try 
            {
                alter = int.Parse(Console.ReadLine());
            }


            catch (OverflowException oex)
            { 
                Console.WriteLine(oex.Message);
                goto Eingabe;
            }
            catch (FormatException fex)
            {
                Console.WriteLine(fex.Message);
                goto Eingabe;
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
                goto Eingabe;
            }


        }
    }
}
