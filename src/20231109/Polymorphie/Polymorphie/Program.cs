using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polymorphie.ShapeTypes;

namespace Polymorphie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shapeList = new Shape[]
            {
                new Kreis(ConsoleColor.Blue,15),
                new Shape("Hexagon", 6, ConsoleColor.DarkRed),
                new Dreieck(ConsoleColor.DarkGreen),
                new VielEck("Quadrat", 4, ConsoleColor.Cyan),
                new Shape("Elypse", 0, ConsoleColor.DarkMagenta)
            };

            //darstellung aller shapes
            DisplayShapes(shapeList);




        }

        private static void DisplayShapes(Shape[] shapeList)
        {
            foreach (var shape in shapeList)
            {
               shape.Draw();
            }
        }
    }
}
