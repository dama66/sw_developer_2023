using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //alt = Array
            var nameArray = new string[]
            {
                "Hans", "Wurst"
            };

            var nameList = new List<string>();

            var dict = new SortedList<DateTime, string>();

            nameList.Add("David");
            nameList.Add("Alex");
            nameList.Add("Adri");

            nameList.Remove("Alex");

            DisplayItems(nameList);
            DisplayItems(nameArray);
        }

        private static void DisplayItems(IEnumerable<string> nameList)
        {
            foreach (var item in nameList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
