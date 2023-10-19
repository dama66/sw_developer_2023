using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using ConsoleTables;

namespace Teilnehmerverwaltung_V2._2
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

            string headerText = "Teilnehmerverwaltung v2.0 @2023 WIFI-Soft";
            var anzahlTeilnehmer = 0;


            //Header ausgeben
            CreateHeader(headerText, ConsoleColor.Yellow, true);

            Teilnehmer[] teilnehmer = new Teilnehmer[]{};

            List<Teilnehmer> listeTeilnehmer = new List<Teilnehmer>();

            //Daten einlesen
            listeTeilnehmer = GetStudentInfos(anzahlTeilnehmer);

            //Ausgabe der Daten
            DisplayStudentInfo(listeTeilnehmer);
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

                if (string.IsNullOrEmpty(inputString))
                {
                    ConsoleColor oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\aERROR: Ungültige Eigabe.");
                    Console.ForegroundColor = oldColor;
                }

            }
            while (string.IsNullOrEmpty(inputString));

            return inputString;
        }

        private static List<Teilnehmer> GetStudentInfos(int anzahl)
        {
            ConsoleKey keyPressed;
            var i = 0;
            var escape = String.Empty;

            List<Teilnehmer> listTeilnehmer = new List<Teilnehmer>();

            do
            {
                listTeilnehmer.Add(new Teilnehmer());

                Teilnehmer temp = listTeilnehmer[i];



                Console.WriteLine($"\nBitte geben Sie die Daten von Teilnehmer{i + 1} ein:");

                temp.Vorname = ReadString("\tVorname:  ");
                temp.Name = ReadString("\tNachname:  ");
                temp.Gebutsdatum = ReadDateTime("\tGeburtsdatum: (dd.mm.yyyy)  ");
                temp.Plz = ReadInt("\tPLZ:  ");
                temp.Ort = ReadString("\tWohnort:  ");

                listTeilnehmer[i] = temp;

                i++;

                if (i > 0)
                {
                    escape = ReadString("Eine weitere Person hizufügen? J/N ");
                }

            } while (escape != "N" && escape != "n");



            return listTeilnehmer;
        }

        private static void DisplayStudentInfo(List<Teilnehmer> studentInfo)
        {
            var table = new ConsoleTable("Name", "Vorname", "Geb. Datum", "PLZ", "Wohnort");

            Console.WriteLine("\n\nDie Teilnehmerdaten:\n");

            for (int i = 0; i < studentInfo.Count; i++)
            {
                table.AddRow($"{studentInfo[i].Vorname}", $"{studentInfo[i].Name}", $"{studentInfo[i].Gebutsdatum.ToShortDateString()}", $"{studentInfo[i].Plz}", $"{studentInfo[i].Ort}");
            }

            table.Write();

            Console.ReadLine();
        }
    }
}
