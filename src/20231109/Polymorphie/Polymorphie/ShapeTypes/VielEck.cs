using System;

namespace Polymorphie.ShapeTypes
{
    internal class VielEck : Shape
    {
        private readonly string _vielEckDescription;


        public VielEck(string vielEckDescription, int vielEckCornerCount, ConsoleColor vielEckColour)
                : base("Vieleck", vielEckCornerCount, vielEckColour)
        {
            _vielEckDescription = vielEckDescription;
        }

        public override string Description
        {
            get { return "Vieleck" + _vielEckDescription; }
        }
    }
}
