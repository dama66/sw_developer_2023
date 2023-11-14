using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Events_GL
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var myMusicDevice = new Radio();

            //subscribe
            myMusicDevice.PowerStateChanged += MyMusicDevice_PowerStateChanged;


            Thread.Sleep(3000);
            myMusicDevice.ChangePowerState(DevicePower.ON);

            //unsubscribe
            myMusicDevice.PowerStateChanged -= MyMusicDevice_PowerStateChanged;
            myMusicDevice.ChangePowerState(DevicePower.OFF);
        }

        private static void MyMusicDevice_PowerStateChanged(object sender, PowerStateChangedEventArgs e)
        {

                Console.WriteLine("Radio ist betriebsbereit");
                Console.WriteLine($"Powerstate: \n\told: {e.OldState}\n\tnew: {e.NewState}");

                var radio = sender as Radio;
                if (radio != null)
                {
                    radio.Play();
                }
            
        }
    }
}
