using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foreachGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Deklaration, Dimensionierung, Initialisierung
            string[] names = new string[]
            {
                "David", "Alex", "Adrina", "Valentina"
            };

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

        }
    }
}
