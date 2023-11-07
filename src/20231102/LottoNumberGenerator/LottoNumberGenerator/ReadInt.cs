using System;

namespace Teilnehmerverwaltung_V2._0
{
    internal class ReadInt
    {

        private string _inputString = string.Empty;
        private int _inputInt = 0;
        private bool _inputIsValid = false;

        private int _minAmount;
        private int _maxAmount;
        private string _inputPrompt;
        private ConsoleColor _inputColour;

        public ReadInt(int minAmount, int maxAmount, string inputPrompt, ConsoleColor inputColour)
        {
            _minAmount = minAmount;
            _maxAmount = maxAmount;
            _inputPrompt = inputPrompt;
            _inputColour = inputColour;
        }

        public int Number { get { return _inputInt; } }

        public void Start()
        {
            do
            {
                Console.Write(_inputPrompt);
                ConsoleColor oldInputColor = Console.ForegroundColor;
                Console.ForegroundColor = _inputColour;
                _inputString = Console.ReadLine();
                Console.ForegroundColor = oldInputColor;

                try
                {
                    _inputInt = int.Parse(_inputString);
                    if (_inputInt >= _minAmount && _inputInt <= _maxAmount)
                    {
                        _inputIsValid = true;
                    }
                    else
                    {
                        ConsoleColor oldColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\aERROR: invalid input! number must be between {_minAmount} and {_maxAmount}");
                        _inputInt = 0;
                        Console.ForegroundColor = oldColor;
                    }

                }
                catch
                {
                    ConsoleColor oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\aERROR: invalid input.");
                    _inputInt = 0;
                    Console.ForegroundColor = oldColor;
                    _inputIsValid = false;
                }
            }
            while (!_inputIsValid);
        }
    }
}