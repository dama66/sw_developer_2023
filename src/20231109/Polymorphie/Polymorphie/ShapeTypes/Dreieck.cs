using System;

namespace Polymorphie.ShapeTypes
{
    internal class Dreieck : VielEck
    {
        public Dreieck(ConsoleColor dreieckColour)
                : base("Dreieck", 3, dreieckColour)
        {

        }
    }
}
