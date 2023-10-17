using System;
using System.Collections.Generic;
using System.Globalization;
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
            var name = String.Empty;
            var vorname = String.Empty;
            var geburtsdatum = DateTime.MinValue;
            var plz = 0;
            var ort = string.Empty;

            string headerText = "Teilnehmerverwaltung v2.0 @2023 WIFI-Soft";

            CreateHeader(headerText, ConsoleColor.Yellow, true);

            Console.WriteLine("Bitte geben Sie die Teilnehmer Daten ein:");

            vorname = ReadString("\tVorname:  ");

            name = ReadString("\tNachname:  ");

            geburtsdatum = ReadDateTime("\tGeburtsdatum: (dd.mm.yyyy)  ");

            plz = ReadInt("\tPLZ:  ");

            ort = ReadString("\tWohnort:  ");

            DisplayStudentInfo(name, vorname, geburtsdatum, plz, ort, ConsoleColor.DarkGreen);
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

        private static DateTime ReadDateTime(string inputPrompt, string inputFormat)
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
            }
            while (!inputIsValid || inputDateTime.Year == DateTime.MinValue.Year);

            return inputDateTime;
        }

        private static DateTime ReadDateTime(string inputPrompt)
        {
           return ReadDateTime(inputPrompt, "dd.MM.yyyy");
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

        private static string ReadString(string inputPrompt)
        {
            string inputString = string.Empty;

            do
            {
                Console.Write(inputPrompt);
                inputString = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(inputString));

            return inputString;
        }

        private static void DisplayStudentInfo(string name, string vorname, DateTime geburtsdatum, int plz, string ort, ConsoleColor outputColour)
        {
            Console.WriteLine("\n\nDie Teilnehmerdaten:");
            Console.WriteLine($"\n\t{vorname}, {name}, {geburtsdatum}, {plz}, {ort}");

        }
    }
}
