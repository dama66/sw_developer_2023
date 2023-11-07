using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoNumberGenerator
{
    internal class RandomIntGenerator
    {
        private int _minValue;
        private int _maxValue;
        private int _tipAmount;
        private int _numbersPerTip;

        private int[][] _result;

        public RandomIntGenerator(int minValue, int maxValue, int tipAmount, int numbersPerTip)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            _tipAmount = tipAmount;
            _numbersPerTip = numbersPerTip;
        }


        public void Start()
        {
            

            Random rnd = new Random();
            int tempResult = 0;

            _result = new int[_tipAmount][];

            for (int j = 0; j < _tipAmount; j++)
            {
                _result[j] = new int[_numbersPerTip];

                for (int i = 0; i < _numbersPerTip; i++)
                {
                    do
                    {
                        tempResult = rnd.Next(_minValue, _maxValue);
                    } while (_result[j].Contains(tempResult));

                    _result[j][i] = tempResult;
                }
            }



        }
        public int[][] Result { get { return _result; } }
    }

        

    
}
