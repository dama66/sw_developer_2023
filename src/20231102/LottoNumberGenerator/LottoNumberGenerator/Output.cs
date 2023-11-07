using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LottoNumberGenerator
{
    internal class Output
    {
        private int top1 = 7;
        private int top2 = 16;

        private int[][] _tips;
        private int _minValue;
        private int _maxValue;

        public Output(int[][] tips, int minValue, int maxValue)
        {
            _tips = tips;
            _minValue = minValue;
            _maxValue = maxValue;
        }


        public void Start()
        {

            Console.WriteLine("Your lottery ticket: ");

            for (int i = 0; i < _tips.Length; i++)
            {
                if (i < 6)
                {
                    Console.SetCursorPosition(i * 25, top1);
                }
                else
                {
                    Console.SetCursorPosition((i - 6) * 25, top2);
                }

                for (int j = _minValue; j <= _maxValue; j++)
                {
                    if (j < 10)
                    {
                        Console.Write(" ");
                    }

                    if (_tips[i].Contains(j))
                    {
                        ConsoleColor old = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{j}  ");
                        Console.ForegroundColor = old;
                    }
                    else
                    {
                        Console.Write($"{j}  ");
                    }

                    var cursorTop = Console.CursorTop;

                    if (j % 6 == 0 && i < 6)
                    {
                        Console.SetCursorPosition(i * 25, cursorTop + 1);
                    }
                    else if (j % 6 == 0 && i >= 6)
                    {
                        Console.SetCursorPosition((i - 6) * 25, cursorTop + 1);
                    }

                }
            }
        }
    }
}
