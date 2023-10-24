using System;
using System.Collections.Generic;
using System.IO;
using Wifi.UITools;

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

            string headerText = "Teilnehmerverwaltung v2.0 @2023 WIFI-Soft";

            //Header ausgeben
            ConsoleTools.CreateHeader(headerText, ConsoleColor.Yellow, true);

            //main Menu
            StartMenu();
        }

        private static void StartMenu()
        {
            int teilnehmerCount = 0;
            Teilnehmer teilnehmer = new Teilnehmer();
            Teilnehmer[] teilnehmerListe;

            string prompt = "What do you want to do?";
            string[] options = { "Add new student", "Read file" };

            Menu MainMenu = new Menu(prompt, options);
            int selectedIndex = MainMenu.Run();

            if (selectedIndex == 0)
            {
                Console.Clear();
                //Abfrage Anzahl Teilnehmer
                teilnehmerCount = ConsoleTools.ReadInt("Bitte Anzahl der Teilnehmer eingeben: ");

                //Teilnehmerliste vorbereiten
                teilnehmerListe = new Teilnehmer[teilnehmerCount];

                //Daten einlesen
                Console.WriteLine("\nBitte geben Sie die Teilnehmer Daten ein:");

                teilnehmerListe = GetStudentInfos(teilnehmerCount);

                //Ausgabe der Daten
                Console.WriteLine("\n\nDie Teilnehmerdaten:");
                DisplayStudentInfo(teilnehmerListe);

                //save to file
                SaveToFile(teilnehmerListe);
            }
            else
            {
                //get files
                List<string> fileList = GetFiles(Environment.CurrentDirectory, false);

                //read file
                ReadFile(fileList);
            }
        }



        private static Teilnehmer GetStudentInfos()
        {
            Teilnehmer teilnehmer;

            teilnehmer.Vorname = ConsoleTools.ReadString("\tVorname:  ");
            teilnehmer.Name = ConsoleTools.ReadString("\tNachname:  ");
            teilnehmer.Gebutsdatum = ConsoleTools.ReadDateTime("\tGeburtsdatum: (dd.mm.yyyy)  ");
            teilnehmer.Plz = ConsoleTools.ReadInt("\tPLZ:  ");
            teilnehmer.Ort = ConsoleTools.ReadString("\tWohnort:  ");

            return teilnehmer;
        }

        private static Teilnehmer[] GetStudentInfos(int amount)
        {

            Teilnehmer[] teilnehmerListe = new Teilnehmer[amount];

            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine($"\nTeilnehmer {i + 1}/{amount}");

                teilnehmerListe[i] = GetStudentInfos();
            }

            return teilnehmerListe;
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

        private static void SaveToFile(Teilnehmer[] teilnehmerListe)
        {
            string prompt = "Do you want to save students to file?";
            string[] options = { "Yes", "No" };

            Menu SelectSave = new Menu(prompt, options);
            int selectedIndex = SelectSave.Run();

            if (selectedIndex == 0)
            {
                string prompt1 = "Please choose the Format";
                string[] options1 = { "csv", "json", "xml" };

                Menu SelectFormat = new Menu(prompt1, options1);
                int selectedFormat = SelectFormat.Run();

                SaveStudentInfoToFile(teilnehmerListe, "Teilnehmerliste", (Format)selectedFormat);
            }
        }

        private static void SaveStudentInfoToFile(Teilnehmer[] students, string filename, Format format)
        {
            using (StreamWriter sw = new StreamWriter($"{filename}.{format}", true))
            {
                if (format == Format.csv)
                {
                    for (int i = 0; i < students.Length; i++)
                    {
                        string dataline =
                            $"{students[i].Vorname}, {students[i].Name}, {students[i].Gebutsdatum.ToShortDateString()}, {students[i].Plz}, {students[i].Ort}";
                        sw.WriteLine(dataline);
                    }
                }
                else if (format == Format.json)
                {
                    for (int i = 0; i < students.Length; i++)
                    {
                        string dataline =
                            "{\n" +
                            "\"first name\": \"" + students[i].Vorname + "\"\n\"last name\": \"" + students[i].Name + "\"\n" +
                            "\"birth date\": \"" + students[i].Gebutsdatum.ToShortDateString() + "\"\n" +
                            "\"postal code\": \"" + students[i].Plz + "\"\n" +
                            "\"residence\": \"" + students[i].Ort + "\"\n},";
                        sw.WriteLine(dataline);
                    }
                }
                else if (format == Format.xml)
                {
                    for (int i = 0; i < students.Length; i++)
                    {
                        string dataline =
                            "\n<firstName>" + students[i].Vorname + @"\n<\firstName>" +
                            "\n<lastName>" + students[i].Name + @"\n<\lastName>" +
                            "\n<birthDate>" + students[i].Gebutsdatum.ToShortDateString() + @"\n<\birthDate>" +
                            "\n<postalCode>" + students[i].Plz + @"\n<\postalCode>" +
                            "\n<residence>" + students[i].Ort + @"\n<\residence>";
                        sw.WriteLine(dataline);
                    }
                }
            }
        }

        private static List<string> GetFiles(string root, bool subFolders)
        {
            List<string> FileArray = new List<string>();
            try
            {
                string[] Files = System.IO.Directory.GetFiles(root);
                string[] Folders = System.IO.Directory.GetDirectories(root);

                for (int i = 0; i < Files.Length; i++)
                {
                    if (Files[i].Contains(".csv") || Files[i].Contains(".json") || Files[i].Contains(".xml"))
                    FileArray.Add(Files[i].ToString());
                }

                if (subFolders == true)
                {
                    for (int i = 0; i < Folders.Length; i++)
                    {
                        FileArray.AddRange(GetFiles(Folders[i], subFolders));
                    }
                }
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
            return FileArray;
        }

        private static void ReadFile(List<string> fileList)
        {
            string prompt = "select the file you want to read:";
            string[] optionsRaw = fileList.ToArray();
            string[] options = new string[optionsRaw.Length];

            for (int i = 0; i < optionsRaw.Length; i++)
            {
                options[i] = optionsRaw[i].Replace(Environment.CurrentDirectory, "");
            }

            Menu SelectFile = new Menu(prompt, options);
            int selectedIndex = SelectFile.Run();

            using (StreamReader sr = new StreamReader(new FileStream(optionsRaw[selectedIndex], FileMode.Open)))
            {
                Console.WriteLine(sr.ReadToEnd());
                Console.ReadLine();
            }
        }
    }
}
