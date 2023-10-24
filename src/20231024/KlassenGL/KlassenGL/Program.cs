using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlassenGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();

            book.StartBorrowing(TimeSpan.FromDays(14));
            book.DisplayInfos();


        }
    }
}
