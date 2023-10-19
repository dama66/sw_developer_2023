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
            int teilnehmerCount = 0;
            Teilnehmer teilnehmer = new Teilnehmer();
            Teilnehmer[] teilnehmerListe;
            string headerText = "Teilnehmerverwaltung v2.0 @2023 WIFI-Soft";

            //Header ausgeben
            CreateHeader(headerText, ConsoleColor.Yellow, true);

            //Abfrage Anzahl Teilnehmer
            teilnehmerCount = ReadInt("Bitte Anzahl der Teilnehmer eingeben: ");

            //Teilnehmerliste vorbereiten
            teilnehmerListe = new Teilnehmer[teilnehmerCount];

            //Daten einlesen
            Console.WriteLine("\nBitte geben Sie die Teilnehmer Daten ein:");
            for (int i = 0; i < teilnehmerListe.Length; i++)
            {
                Console.WriteLine($"\nTeilnehmer {i + 1}/{teilnehmerListe.Length}");
                //TODO: GetStudentInfos() kann auch als Überladung mit der Anzahl als input realiserit werden....
                teilnehmerListe[i] = GetStudentInfos();
            }

            //Ausgabe der Daten
            Console.WriteLine("\n\nDie Teilnehmerdaten:");
            DisplayStudentInfo(teilnehmerListe);

            //TODO: implement .json and .xml too!!
            SaveStudentInfoToFile(teilnehmerListe, "Teilnehmerliste.csv");

            //TODO: Datei mit StreamReader einlesen (LoadStudentInfoFromFile)
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

        private static Teilnehmer GetStudentInfos()
        {
            Teilnehmer teilnehmer;

            teilnehmer.Vorname = ReadString("\tVorname:  ");
            teilnehmer.Name = ReadString("\tNachname:  ");
            teilnehmer.Gebutsdatum = ReadDateTime("\tGeburtsdatum: (dd.mm.yyyy)  ");
            teilnehmer.Plz = ReadInt("\tPLZ:  ");
            teilnehmer.Ort = ReadString("\tWohnort:  ");

            return teilnehmer;
        }

        private static void DisplayStudentInfo(Teilnehmer studentInfo)
        {
            Console.WriteLine($"\n\t{studentInfo.Vorname}, {studentInfo.Name}, {studentInfo.Gebutsdatum.ToShortDateString()}, {studentInfo.Plz}, {studentInfo.Ort}");

        }

        private static void DisplayStudentInfo(Teilnehmer[] studentInfos)
        {
            for (int i = 0; i < studentInfos.Length; i++)
            {
                DisplayStudentInfo(studentInfos[i]);
            }
        }

        private static void SaveStudentInfoToFile(Teilnehmer[] students, string filename)
        {
            // Dateizugriff immer mit "using". Damit ist sichergestellt dass die Datei nach ende oder bei Absturz die Datei wieder freigegeben wird.
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                for (int i = 0; i < students.Length; i++)
                {
                    string dataline = $"{students[i].Vorname}, {students[i].Name}, {students[i].Gebutsdatum.ToShortDateString()}, {students[i].Plz}, {students[i].Ort}";
                    sw.WriteLine(dataline);
                }
            }

            
        }
    }
}
