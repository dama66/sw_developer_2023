using System;

namespace Polymorphie.ShapeTypes
{
    internal class Kreis : Shape
    {
        private int _radius;
        private ConsoleColor _color;



        public Kreis(ConsoleColor kreisColour, int radius)
                : base("Kreis", 0, kreisColour)
        {
            _radius = radius;
            _color = kreisColour;
        }

        public int Radius { get { return _radius; } set {  _radius = value; } }

        public override void Draw()
        {
            var oldColor = Console.ForegroundColor;

            Console.ForegroundColor = _color;
            Console.WriteLine($"[{Description}] Radius: {_radius}");
            Console.ForegroundColor = oldColor;
        }
    }
}
