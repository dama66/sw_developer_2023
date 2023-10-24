using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.UITools
{
    /// <summary>
    /// Sammelsurium von Methoden für die Arbeit in der Console
    /// </summary>
    public abstract class ConsoleTools
    {
        /// <summary> 
        /// Liefert eine Eingabe als String zurück. string.Empty und NULL werden nicht akzeptiert. 
        /// </summary>
        /// <param name="headerText">Tiltel im Header</param>
        /// <param name="headerTextColor">Farbe für den Text im Header</param>
        /// <param name="clearScreen">BOOL für das Löschen der Console vor der Ausgabe</param>
        public static void CreateHeader(string headerText, ConsoleColor headerTextColor, bool clearScreen)
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
        /// <summary>
        /// Liefert eine Eigabe als DateTime zurück. Das Format für das Datum kann ausgewählt werden.
        /// </summary>
        /// <param name="inputPrompt"></param>
        /// <param name="inputFormat"></param>
        /// <returns></returns>
        public static DateTime ReadDateTime(string inputPrompt, string inputFormat)
        {
            var inputString = string.Empty;
            var inputDateTime = DateTime.MinValue;
            var inputIsValid = false;

            do
            {
                Console.Write(inputPrompt);
                inputString = Console.ReadLine();
                Console.ResetColor();

                try
                {
                    inputDateTime = DateTime.ParseExact(inputString, inputFormat, CultureInfo.InvariantCulture);
                    inputIsValid = true;
                }
                catch
                {
                    ConsoleColor oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\aERROR: Ungültige Datumseigabe.");
                    inputDateTime = DateTime.MinValue;
                    Console.ForegroundColor = oldColor;
                    inputIsValid = false;
                }
            } while (!inputIsValid || inputDateTime.Year == DateTime.MinValue.Year);

            return inputDateTime;
        }
        /// <summary>
        /// Liefert eine Eigabe als DateTime zurück. Es wird nur das Format dd.MM.yyyy akzeptiert.
        /// </summary>
        /// <param name="inputPrompt">Text für die Eingabeaufforderung</param>
        /// <returns></returns>
        public static DateTime ReadDateTime(string inputPrompt)
        {
            return ReadDateTime(inputPrompt, "dd.MM.yyyy");
        }
        /// <summary>
        /// Liefert eine Eigabe als int zurück. Es werden nur valide Zahlen akzeptiert
        /// </summary>
        /// <param name="inputPrompt">Text für die Eingabeaufforderung</param>
        /// <returns></returns>
        public static int ReadInt(string inputPrompt)
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
            } while (!inputIsValid);

            return inputInt;
        }
        /// <summary>
        /// Liefert eine Eigabe als string zurück. string.Empty und NULL werden nicht akzeptiert.
        /// </summary>
        /// <param name="inputPrompt">Text für die Eingabeaufforderung</param>
        /// <returns></returns>
        public static string ReadString(string inputPrompt)
        {
            string inputString = string.Empty;

            do
            {
                Console.Write(inputPrompt);
                inputString = Console.ReadLine();

                if (string.IsNullOrEmpty(inputString))
                {
                    ConsoleColor oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\aERROR: Ungültige Eigabe.");
                    Console.ForegroundColor = oldColor;
                }

            } while (string.IsNullOrEmpty(inputString));

            return inputString;
        }

    }
}
