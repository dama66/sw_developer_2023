using System;

namespace Shapes.Shapes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myShapeList = new Shape[]
            {
                new Dreieck(ConsoleColor.Red),
                new Kreis(ConsoleColor.Green),
                new VielEck("Hexagon", 6, ConsoleColor.Yellow)
            };

            foreach (var shape in myShapeList)
            {
                Console.ForegroundColor = shape.Colour;

                shape.Draw();
            }
            Console.ResetColor();
        }
    }
}
