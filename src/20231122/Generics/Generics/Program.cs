using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int elemetCount = 23;

            var myValues = CreateIntArray(elemetCount, -1);

            var MyOtherValues = CreateArray<bool>(33, false);

            var MyOtherValues2 = CreateArray<DateTime>(55, DateTime.MinValue);

            var zahl = ReadNumeric<int>("Bitte Anzahl eingeben:");
            var gehalt = ReadNumeric<decimal>("Startgehalt eingeben:");
            var gewicht = ReadNumeric<double>("Gewicht eingeben: ");
        }

        public static T ReadNumeric<T>(string inputPrompt) where T : struct
        {
            string input = string.Empty;
            T inputValue = default(T);
            Type type = typeof(T);


            bool inputIsValid = false;

            do
            {
                Console.Write(inputPrompt);
                input = Console.ReadLine();

                try
                {
                  var methodInfo = type.GetMethod("Parse", new Type[] {typeof(string)});
                  if (methodInfo != null)
                  {
                    inputValue = (T)  methodInfo.Invoke(null, new object[] { input });
                    inputIsValid = true;
                    }
                    
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);

                    inputValue = default(T);
                    inputIsValid = false;
                }
            }
            while (!inputIsValid);

            return inputValue;
        }

        private static T[] CreateArray<T>(int elemetCount, T initValue) 
        {
            var array = new T[elemetCount];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = initValue;
            }

            return array;
        }

        private static int[] CreateIntArray(int elemetCount, int initValue)
        {
            var array = new int[elemetCount];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = initValue;
            }

            return array;
        }
    }
}
