using System;

namespace Events_GL
{
    internal delegate void PowerStateChangedHandler(object sender, PowerStateChangedEventArgs e);



    /// <summary>
    /// Dies ist eine einfache Umsetzung eines FM Radio Empfängers
    /// </summary>
    internal class Radio
    {
        private double _frequency;
        private DevicePower _powerState;

        public Radio()
        {
            _frequency = 87.6;
            _powerState = DevicePower.OFF;
        }

        /// <summary>
        /// occures when PowerState has changed
        /// </summary>
        public event PowerStateChangedHandler PowerStateChanged;

        public DevicePower PowerState
        {
            get { return _powerState; }
        }

        /// <summary>
        /// Die Ausstrahlung von UKW/FM Radioprogrammen erfolgt im Frequenzbereich 
        /// zwischen 87,6 und 107,9 MHz. 
        /// </summary>
        public double Frequency
        {
            get { return _frequency; }
            set
            {
                if (value >= 87.6 && value <= 107.9)
                {
                    _frequency = value;
                }
            }
        }
        public void ShowState()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Radio \n  Frequenz: {_frequency} MHz");
            Console.WriteLine($"  Status:   {_powerState}");
            Console.WriteLine("-------------------------------------------------");
        }

        public void ChangePowerState(DevicePower newPowerState)
        {
            if (_powerState == newPowerState)
            {
                return;
            }


            switch (newPowerState)
            {
                case DevicePower.UNKNOWN:
                case DevicePower.DEFECTIVE:
                    //Status kann nicht von ext. gesetzt werden
                    break;

                case DevicePower.OFF:
                case DevicePower.STANDBY:
                case DevicePower.ON:
                    var oldPowerState = _powerState;
                    _powerState = newPowerState;

                    // Ereignis abfeuern
                    OnPowerStateChanged(oldPowerState, newPowerState);

                    break;

                default:
                    throw new ArgumentException("Unbekannter DeviceState erkannt.");
            }
        }

        protected void OnPowerStateChanged(DevicePower oldPowerState, DevicePower newPowerState)
        {
            PowerStateChanged?.Invoke(this, new PowerStateChangedEventArgs(oldPowerState, newPowerState));
        }

        public void Play()
        {
            if (_powerState == DevicePower.ON)
            {
                Console.WriteLine($"Ich spiele nun die Inhalte vom Sender auf der Frequence {_frequency} MHz...");
            }
        }
    }
}