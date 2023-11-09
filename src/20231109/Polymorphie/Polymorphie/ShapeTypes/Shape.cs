using System;

namespace Polymorphie.ShapeTypes
{
    internal class Shape
    {
        private string _description;
        private int _cornerCount;
        private ConsoleColor _color;

        public Shape(string description, int cornerCount) 
            : this(description, cornerCount, ConsoleColor.Green) { }
        public Shape (string description, int cornerCount, ConsoleColor color)
        {
            _description = description;
            _cornerCount = cornerCount;
            _color = color;
        }

        public virtual string Description { get { return _description; } }
        public int CornerCount { get { return _cornerCount; } }
        public ConsoleColor Colour { get { return _color; } set { _color = value; ; }
        }

        public virtual void Draw()
        {
            var oldColor = Console.ForegroundColor;

            Console.ForegroundColor = _color;
            Console.WriteLine($"[{_description}] Corners: {_cornerCount}");
            Console.ForegroundColor = oldColor;
        }

    }
}
