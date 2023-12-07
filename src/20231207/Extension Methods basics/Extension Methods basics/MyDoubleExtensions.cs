using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Methods_basics
{
    public static class MyDoubleExtensions
    {
        public static string ToCurrency(this double valueToConvert)
        {
        return $"EUR {valueToConvert:F2}";
        }

    }
}
