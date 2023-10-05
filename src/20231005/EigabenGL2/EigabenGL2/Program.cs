using System;

namespace EigabenGL2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;
            string eingabeAlter = string.Empty;
            int alter = 0;

            Console.Write("Bitte Name eingeben: ");
            name = Console.ReadLine();

            Console.WriteLine($"Hallo {name}, wie geht's?");

            Console.Write("Bitte Alter eingeben: ");
            eingabeAlter = Console.ReadLine();

            //eingabeAlter = "40";
            alter = int.Parse( eingabeAlter );

            Console.WriteLine($"{name}, Sie sind {alter} Jahre alt.");
            Console.WriteLine($"Sie sind im Jahr {2023 - alter} geboren.");
        }
    }
}
