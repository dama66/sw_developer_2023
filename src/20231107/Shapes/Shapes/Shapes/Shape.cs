using System;

namespace Shapes.Shapes
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

        public string Description { get { return _description; } }
        public int CornerCount { get { return _cornerCount; } }
        public ConsoleColor Colour { get { return _color; } set { _color = value; ; }
        }

        public void Draw()
        {
            Console.WriteLine($"[{_description}] Corners: {_cornerCount}");
        }

    }
}
