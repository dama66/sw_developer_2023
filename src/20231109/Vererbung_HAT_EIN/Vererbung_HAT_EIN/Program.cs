using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vererbung_HAT_EIN
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var myRadio = new Radio();

            //myRadio.ShowState();
            //myRadio.ChangePowerState(DevicePower.ON);

            //myRadio.Frequency = 102.6;
            //myRadio.ShowState();
            //myRadio.Play();

            var meinAuto = new Vehicle(); 

            meinAuto.SetEntertainmentPower(true);

            meinAuto.ShowInfo();

        }
    }
}
