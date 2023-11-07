using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung
{
    internal class Bike : Vehicle
    {
        private int _suspensionTravel;

        public Bike() 
            : base("Vespa", ConsoleColor.DarkYellow, 5, 45) 
        {
            _suspensionTravel = 80;
        }

        public Bike (int suspensionTravel, string bikeDescription, ConsoleColor bikeColour, int ps, int maxSpeed) 
            : base(bikeDescription, bikeColour, ps, maxSpeed)
        {
            _suspensionTravel = suspensionTravel;
        }

        public int SuspensionTravel { get {  return _suspensionTravel; } }

    }
}
