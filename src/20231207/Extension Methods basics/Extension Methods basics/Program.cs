using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Methods_basics
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double einWert = 5.93457;

            Console.WriteLine($"Der Artikel kostet: EUR {einWert:F2}");

            Console.WriteLine($"Der Artikel kostet: {einWert.ToCurrency()}");
        }
    }
}
