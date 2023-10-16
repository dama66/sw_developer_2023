using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Zahlenraten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variablen deklarieren
            const int minValue = 0;
            const int maxValue = 100;
            int Ratezahl = -1;
            int anzahlVersuche = 5;
            TimeSpan versuchsZeit = TimeSpan.FromSeconds(10);
            TimeSpan restZeit = TimeSpan.Zero;

            //Zufallsgenerator
            Random rnd = new Random();
            int zufallsZahl = rnd.Next(0, 100);

            //Header
            Header("Zahlenraten");

            //Eingabe der Daten
            EingabeUndValiderung(minValue, maxValue, anzahlVersuche, Ratezahl, zufallsZahl, versuchsZeit, restZeit);

            //Ausgabe Ende
            AusgabeEnde(anzahlVersuche, zufallsZahl, Ratezahl, restZeit);
        }

        static void Header(string header)
        {
            //Init Variables
            int xTitelPos = 0;

        //Program header
            Console.WriteLine(new string ('*', Console.WindowWidth - 1));
            Console.WriteLine(new string ('*', Console.WindowWidth - 1));
            Console.WriteLine(new string ('*', Console.WindowWidth - 1));

            //cursor position for title
            xTitelPos = (Console.WindowWidth - header.Length) / 2;
            Console.SetCursorPosition(xTitelPos, 1);
            Console.Write(header);

            //reset cursor position
            Console.SetCursorPosition(0, 4);
            //set console title
            Console.Title = header;
        }

        static void EingabeUndValiderung(int minValue, int maxValue, int anzahlVersuche, int Ratezahl, int zufallsZahl, TimeSpan versuchsZeit, TimeSpan restZeit)
        {
            string eingabe = String.Empty;
            bool eingabeIstZahl = false;
            
            
            var startZeit = DateTime.Now.TimeOfDay;

            Console.WriteLine($"Ich denke an eine Uahl zwischen {minValue}...{maxValue}:");

            do
            {
                restZeit = versuchsZeit - (DateTime.Now.TimeOfDay - startZeit);

                if (restZeit.Seconds < 0)
                {
                    restZeit = TimeSpan.Zero;
                }

                Console.WriteLine($"{anzahlVersuche} Versuche und {restZeit.Seconds}s übrig...");
                Console.Write("deine Zahl:   ");
                eingabe = Console.ReadLine();
                anzahlVersuche--;

                try
                {
                    Ratezahl = int.Parse(eingabe);
                    eingabeIstZahl = true;
                }
                catch
                {
                    Console.SetCursorPosition(35, Console.CursorTop - 1);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("die Eigabe ist keine Zahl!");
                    Console.ResetColor();
                    eingabeIstZahl = false;

                }

                if (eingabeIstZahl && (Ratezahl < minValue || Ratezahl > maxValue))
                {
                    Console.WriteLine("Die eigegebene Zahl liegt ausserhalb des gültigen Bereichs!");
                }
                else if (eingabeIstZahl && Ratezahl < zufallsZahl)
                {
                    Console.WriteLine("die gesuchte Zahl ist grösser....\n");
                }
                else if (eingabeIstZahl && Ratezahl > zufallsZahl)
                {
                    Console.WriteLine("die gesuchte Zahl ist kleiner....\n");
                }


            } while (anzahlVersuche > 0 && restZeit.Seconds > 0 && zufallsZahl != Ratezahl);
        }

        static void AusgabeEnde(int anzahlVersuche, int zufallsZahl, int Ratezahl, TimeSpan restZeit)
        {
            if (anzahlVersuche <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nVersuche aufgebraucht: Du hast die Zahl {zufallsZahl} leider nicht erraten..... :( ");
                Console.ResetColor();
            }
            else if (restZeit.Seconds <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nZeit abgelaufen: Du hast die Zahl {zufallsZahl} leider nicht erraten..... :( ");
                Console.ResetColor();
            }
            else if (Ratezahl == zufallsZahl)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\ndu hast die Zahl {zufallsZahl} erraten!!!!");
                Console.ResetColor();
            }
        }
    }
}