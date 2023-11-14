using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Events_GL
{
    internal delegate void DoSomethingDelegate(string message);

    internal class Program
    {
        static void Main(string[] args)
        {
            int i;
            DoSomethingDelegate doSomething;

            i = 0;
            doSomething = HelloWorld;

            doSomething("David");

            doSomething = PrintColoredMessage;

            doSomething("David");

        }

        static void HelloWorld(string Name)
        {
            Console.WriteLine($"Hello World, { Name}");
            
        }

        static void PrintColoredMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();

        }

    }
}
