using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Teilnehmerverwaltung_V2._0
{
    internal class Program
    {
        /*
        Implementieren Sie eine Applikation mit der beliebig viele Teilnehmerdaten 
        erfasst und dargestellt werden können. 
        Folgende Anforderung sollen dabei erfüllt werden:
           
           - max. Anzahl der Teilnehmer soll zu Beginn vom User befragt werden
           - Einlesen folgender Daten:
             - Name, Vorname
             - Geburtsdatum
             - PLZ, Ort
           - Fehlertolerante Eingaben
           - verwenden sie Methoden wo sinnvoll
           - verwenden sie Farben
           - Teilnehmerdaten sollen nach der Eingabe tabellarisch ausgegeben werden
         */

        static void Main(string[] args)
        {
            const int minValue = 1; 
            const int maxValue = 45;
            const int numbersPerTip = 6;
            var tipAmount = 0;
            string headerText = "Lottery Ticket Generator";
            int[] tipNumbers = new int[numbersPerTip];

   

            //Header
            CreateHeader(headerText, ConsoleColor.Yellow, true);

            //Amount query
            tipAmount = ReadInt("Please enter number of tips: ");

            int[][] tips = new int[tipAmount][];
            //Random int generator

            tips = RandomIntGenerator(minValue, maxValue, tipAmount, numbersPerTip);

            //output
            LotteryTicketOutput(tips, minValue, maxValue);

            Console.ReadLine();
        }



        private static void CreateHeader(string headerText, ConsoleColor headerTextColor, bool clearScreen)
        {
            //Init Variables
            int xTitelPos = 0;

            if (clearScreen)
            {
                Console.Clear();
            }

            //Program header
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));

            //cursor position for title
            xTitelPos = (Console.WindowWidth - headerText.Length) / 2;
            Console.SetCursorPosition(xTitelPos, 1);

            //write Header
            ConsoleColor oldColour = Console.ForegroundColor;
            Console.ForegroundColor = headerTextColor;
            Console.Write(headerText);
            Console.ForegroundColor = oldColour;

            //reset cursor position
            Console.SetCursorPosition(0, 4);
            //set console title
            Console.Title = headerText;
        }

        private static int ReadInt(string inputPrompt)
        {
            var inputString = string.Empty;
            var inputInt = 0;
            var inputIsValid = false;

            do
            {
                Console.Write(inputPrompt);
                inputString = Console.ReadLine();
                Console.ResetColor();

                try
                {
                    inputInt = int.Parse(inputString);
                    inputIsValid = true;
                }
                catch
                {
                    ConsoleColor oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\aERROR: Ungültige Zahleneigabe.");
                    inputInt = 0;
                    Console.ForegroundColor = oldColor;
                    inputIsValid = false;
                }
            }
            while (!inputIsValid);

            return inputInt;
        }

        private static int[][] RandomIntGenerator(int minValue, int maxValue, int tipAmount, int numbersPerTip)
        {
            int[][] result = new int[tipAmount][];

            for (int j = 0; j < tipAmount; j++)
            {
                result[j] = new int[numbersPerTip];

                for (int i = 0; i < numbersPerTip; i++)
                {
                   
                    Random rnd = new Random();
                    result[j][i] = rnd.Next(minValue, maxValue);
                }
            }

            return result;
        }

        private static void LotteryTicketOutput(int[][] tips, int minValue, int maxValue)
        {
            Console.WriteLine("Your lottery ticket: ");

            for (int i = 0; i < tips.Length; i++)
            {
                if (i == 1)
                {
                    Console.SetCursorPosition(25, 6);
                }
                if (i == 2)
                {
                    Console.SetCursorPosition(50, 6);
                }

                for (int j = minValue; j <= maxValue; j++)
                {
                    if (j < 10)
                    {
                        Console.Write(" ");
                    }

                    if (tips[i].Contains(j))
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

                    var cursorLeft = Console.CursorLeft;
                    var cursorTop = Console.CursorTop;
                    
                    //if (j <=6 && i == 1)
                    //{
                    //    Console.SetCursorPosition(25, 7);
                    //}

                    if (j % 6 == 0 && i == 1)
                    {
                        Console.SetCursorPosition(25, cursorTop + 1);
                    }
                    else if (j % 6 == 0 && i == 2)
                    {
                        Console.SetCursorPosition(50, cursorTop + 1);
                    }
                    else if (j % 6 == 0)
                    {
                        Console.SetCursorPosition(0, cursorTop+1);
                    }
                }


            }

        }
    }
}