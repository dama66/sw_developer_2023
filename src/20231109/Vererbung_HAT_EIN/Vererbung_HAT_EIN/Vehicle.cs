using System;

namespace Vererbung_HAT_EIN
{
    internal class Vehicle
    {
        private string _description;
        private ConsoleColor _colour;
        private int _ps;
        private int _currentSpeed;
        private int _maxSpeed;

        private Radio _vehicleRadio;

        public Vehicle()
        {
            _description = "Familienkutsche";
            _colour = ConsoleColor.Blue;
            _ps = 140;
            _maxSpeed = 187;

            _currentSpeed = 0;
            _vehicleRadio = new Radio();
        }

        public Vehicle(string description, ConsoleColor colour, int ps, int maxSpeed)
        {
            _description = description;
            _colour = colour;
            _ps = ps;
            _maxSpeed = maxSpeed;

            _currentSpeed = 0;
            _vehicleRadio = new Radio();
        }
        public Radio VehicleRadio { get { return _vehicleRadio; } }
        public string Description { get { return _description; } }
        public ConsoleColor Colour { get { return _colour; } }
        public int Ps { get { return _ps; } }
        public int CurrentSpeed { get { return _currentSpeed; } }
        public int MaxSpeed { get { return _maxSpeed; } }

        public void SetEntertainmentPower(bool isOn)
        {
            if (isOn)
            {
                _vehicleRadio.ChangePowerState(DevicePower.ON);
            }
            else
            {
                _vehicleRadio.ChangePowerState(DevicePower.OFF);
            }
        }

        public void MakeSound()
        {
            _vehicleRadio.Play();
        }

        public void SpeedUp(int delta)
        {
            if (_currentSpeed + delta < 0)
            {
                _currentSpeed = 0;
            }
            else if (_currentSpeed + delta > _maxSpeed)
            {
                _currentSpeed = _maxSpeed;
            }
            else
            {
                _currentSpeed += delta;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_description.ToUpper()} - {_ps} PS");
            Console.WriteLine($"Speed: {_currentSpeed} of max {_maxSpeed} km/h\n");
            _vehicleRadio.ShowState();
        }


    }
}