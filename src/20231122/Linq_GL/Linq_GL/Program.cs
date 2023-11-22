using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;


namespace Linq_GL
{
    public delegate void DoSomething(string data);

    public delegate bool FilterHandler(int value);

    internal class Program
    {
        static void Main(string[] args)
        {
            DoSomething doSomething = PrintMessage;

            doSomething("Dies ist ein Test!");

            //anonyme Methoden
            DoSomething doAnonym = delegate (string outputData)
             {
                 Console.WriteLine("Anonyme Methode:");
                 Console.WriteLine("\t" + outputData);
             };

            doAnonym("Anonym....");


            #region pratischer Einsatz von anonymen MEthoden

            // Aufruf Timer mit delegate

            //Timer timer = new Timer();

            //timer.Interval = 1000;
            //timer.Elapsed += delegate (object sender, ElapsedEventArgs e)
            //{
            //    Console.Write(".");
            //};

            //timer.Start();

            //while (true) ;

            #endregion

            //Lambda Expression
            doAnonym = (string outputData) =>
            {
                Console.WriteLine("Anonyme Methode:");
                Console.WriteLine("\t" + outputData);
            };

            doAnonym("lambda expression");

            //kurz
            doAnonym = (outputData) =>
            {
                Console.WriteLine(outputData);
            };

            //kürzer
            doAnonym = (outputData) => Console.WriteLine(outputData);

            //noch kürzer
            doAnonym = outputData => Console.WriteLine(outputData);

            //klassische Lambda Expression
            doAnonym = x => Console.WriteLine(x);

            //Anwendung Lambda Expressions
            int[] myValues = { 11, 22, 33, 44, 55, 66, 77, 88, 99 };

            // var filterValues = Filter(myValues, FilterEvenValues);
            var filterValues = Filter(myValues, x => x % 2 == 0);

            filterValues = Filter(myValues, x => x > 30);
            filterValues = Filter(myValues, x => x < 30 && x > 10);

            //Actions ==> Delegate Methode mit Rückgabetype == void
            //Func ==> Delegate Methode mit Rückgabetype != void
            //Predicate ==> Delegate Methode mit Rückgabetype == bool


        }

        private static bool FilterEvenValues(int value)
        {
            return value % 2 == 0;
        }

        private static bool FilterOddValues(int value)
        {
            return value % 2 != 0;
        }

        private static int[] Filter(int[] Valuelist, FilterHandler handler)
        {
            var selectedValueList = new List<int>();
            foreach (int value in Valuelist)
            {
                if (handler(value))
                {
                    selectedValueList.Add(value);
                }
            }

            return selectedValueList.ToArray();
        }


        private static void PrintMessage(string data)
        {
            Console.WriteLine(data);
        }
    }
}
