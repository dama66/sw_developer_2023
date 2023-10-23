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
            const int minAmount = 1;
            const int maxAmount = 12;
            const int numbersPerTip = 6;
            var tipAmount = 0;
            string headerText = "Lottery Ticket Generator";
            int[] tipNumbers = new int[numbersPerTip];


            Console.WindowWidth = 151;


            //Header
            CreateHeader(headerText, ConsoleColor.Yellow, true);

            //Amount query
            tipAmount = ReadInt(minAmount, maxAmount, "Please enter number of tips (1..12): ", ConsoleColor.Yellow);

            // Declare and init jagged Array
            int[][] tips = new int[tipAmount][];

            for (int i = 0; i < tipAmount; i++)
            {
                tips[i] = new int[numbersPerTip];
            }

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

        private static int ReadInt(int minAmount, int maxAmount, string inputPrompt, ConsoleColor inputColour)
        {
            var inputString = string.Empty;
            var inputInt = 0;
            var inputIsValid = false;

            do
            {
                Console.Write(inputPrompt);
                ConsoleColor oldInputColor = Console.ForegroundColor;
                Console.ForegroundColor = inputColour;
                inputString = Console.ReadLine();
                Console.ForegroundColor = oldInputColor;

                try
                {
                    inputInt = int.Parse(inputString);
                    if (inputInt >= minAmount && inputInt <= maxAmount)
                    {
                        inputIsValid = true;
                    }
                    else
                    {
                        ConsoleColor oldColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\aERROR: invalid input! number must be between {minAmount} and {maxAmount}");
                        inputInt = 0;
                        Console.ForegroundColor = oldColor;
                    }

                }
                catch
                {
                    ConsoleColor oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\aERROR: invalid input.");
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
            Random rnd = new Random();
            int tempResult = 0;

            for (int j = 0; j < tipAmount; j++)
            {
                result[j] = new int[numbersPerTip];

                for (int i = 0; i < numbersPerTip; i++)
                {
                    do
                    {
                        tempResult = rnd.Next(minValue, maxValue);
                    } while (result[j].Contains(tempResult));
                    
                    result[j][i] = tempResult;
                }
            }

            return result;
        }

        private static void LotteryTicketOutput(int[][] tips, int minValue, int maxValue)
        {
            var top1 = 7;
            var top2 = 16;

            Console.WriteLine("Your lottery ticket: ");

            for (int i = 0; i < tips.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.SetCursorPosition(0, top1);
                        break;

                    case 1:
                        Console.SetCursorPosition(25, top1);
                        break;

                    case 2:
                        Console.SetCursorPosition(50, top1);
                        break;

                    case 3:
                        Console.SetCursorPosition(75, top1);
                        break;

                    case 4:
                        Console.SetCursorPosition(100, top1);
                        break;

                    case 5: 
                        Console.SetCursorPosition(125, top1);
                        break;

                    case 6:
                        Console.SetCursorPosition(0, top2);
                        break;

                    case 7:
                        Console.SetCursorPosition(25, top2);
                        break;

                    case 8:
                        Console.SetCursorPosition(50, top2);
                        break;

                    case 9:
                        Console.SetCursorPosition(75, top2);
                        break;

                    case 10:
                        Console.SetCursorPosition(100, top2);
                        break;

                    case 11:
                        Console.SetCursorPosition(125, top2);
                        break;
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

                    #region cursor positioning
                    var cursorTop = Console.CursorTop;

                    if (j % 6 == 0 && i == 0)
                    {
                        Console.SetCursorPosition(0, cursorTop + 1);
                    }
                    else if (j % 6 == 0 && i == 1)
                    {
                        Console.SetCursorPosition(25, cursorTop + 1);
                    }
                    else if (j % 6 == 0 && i == 2)
                    {
                        Console.SetCursorPosition(50, cursorTop + 1);
                    }
                    else if (j % 6 == 0 && i == 3)
                    {
                        Console.SetCursorPosition(75, cursorTop + 1);
                    }
                    else if (j % 6 == 0 && i == 4)
                    {
                        Console.SetCursorPosition(100, cursorTop + 1);
                    }
                    else if (j % 6 == 0 && i == 5)
                    {
                        Console.SetCursorPosition(125, cursorTop + 1);
                    }
                    else if (j % 6 == 0 && i == 6)
                    {
                        Console.SetCursorPosition(0, cursorTop + 1);
                    }
                    else if (j % 6 == 0 && i == 7)
                    {
                        Console.SetCursorPosition(25, cursorTop + 1);
                    }
                    else if (j % 6 == 0 && i == 8)
                    {
                        Console.SetCursorPosition(50, cursorTop + 1);
                    }
                    else if (j % 6 == 0 && i == 9)
                    {
                        Console.SetCursorPosition(75, cursorTop + 1);
                    }
                    else if (j % 6 == 0 && i == 10)
                    {
                        Console.SetCursorPosition(100, cursorTop + 1);
                    }
                    else if (j % 6 == 0 && i == 11)
                    {
                        Console.SetCursorPosition(125, cursorTop + 1);
                    }
                    #endregion
                }


            }

        }
    }
}