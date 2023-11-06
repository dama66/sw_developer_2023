using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instanzieren
           Book myBook = new Book(255, "Die Unendliche Geschichte", "Michael Ender", "X-654646-665465-9", 26.50m);


            myBook.DisplayInfo();

            //myBook.StartBorrowing(TimeSpan.FromDays(7));

           

            //myBook.DisplayInfo();
            Console.ReadLine();
        }
    }
}
