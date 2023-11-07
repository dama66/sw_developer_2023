using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Bike Vespa = new Bike();
            //Bike Ktm = new Bike(180, "KTM", ConsoleColor.Cyan, 23, 75);

            Vehicle[] myVehicleList = new Vehicle[]
            {
                new Vehicle(),
                new Vehicle("alter Kübel", ConsoleColor.DarkYellow, 36, 125),
                new Vehicle("Rennwagen", ConsoleColor.Red, 560, 350),
                new Bike(),
                new Bike(180, "KTM", ConsoleColor.Cyan, 23, 75)
             };

            foreach (var vehicle in myVehicleList)
            {
                Console.ForegroundColor = vehicle.Colour;

                vehicle.ShowInfo();
            }
            Console.ResetColor();
        }
    }

}
