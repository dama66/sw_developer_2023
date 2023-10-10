using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration
{
    internal class Program
    {
        static void Main(string[] args)
        {

         for (int i = 0; i < 5; i++) 
            {
                Console.WriteLine(i);
            }

         string input = string.Empty;

         while (input.Length <5)
            {
                Console.Write("Ihre Eingabe:");
                input = Console.ReadLine();
            }

            do
            {
                Console.Write("Ihre Eingabe:");
                input = Console.ReadLine();
            }
            while (input.Length < 5);
        }
    }
}
