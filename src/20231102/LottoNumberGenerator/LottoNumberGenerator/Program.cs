using LottoNumberGenerator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Wifi.UITools;


namespace Teilnehmerverwaltung_V2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int minValue = 1;
            const int maxValue = 45;
            const int minAmount = 1;
            const int maxAmount = 12;
            const int numbersPerTip = 6;
            int tipAmount = 0;
            string headerText = "Lottery Ticket Generator";
            int[] tipNumbers = new int[numbersPerTip];


            Console.WindowWidth = 151;


            //Header
            ConsoleTools.CreateHeader(headerText, ConsoleColor.Yellow, true);

            //Amount query
            ReadInt Read = new ReadInt(minAmount, maxAmount, "Please enter number of tips (1..12): ", ConsoleColor.Yellow);

            Read.Start();

            tipAmount = Read.Number;

            // Declare and init jagged Array
            int[][] tips = new int[tipAmount][];

            for (int i = 0; i < tipAmount; i++)
            {
                tips[i] = new int[numbersPerTip];
            }

            //Random int generator
            RandomIntGenerator Rnd = new RandomIntGenerator(minValue, maxValue, tipAmount, numbersPerTip);

            Rnd.Start();

            tips = Rnd.Result;

            //output
            Output LotteryTicketOutput = new Output(tips, minValue, maxValue);

            LotteryTicketOutput.Start();

            Console.ReadLine();
        }
    }
}