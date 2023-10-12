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

            int xTitelPos = 0;
            int anzahlVersuche = 5;
            TimeSpan versuchsZeit = TimeSpan.FromSeconds(30);
            string eingabe = String.Empty;
            int Ratezahl = -1;
            bool eingabeIstZahl = false;
            var startZeit = DateTime.Now.TimeOfDay;
            TimeSpan restZeit;

            

            //Zufallsgenerator erzeugen
            Random rnd = new Random();

            //Zufallszahl ermitteln
            int zufallsZahl = rnd.Next(0, 100);

            Console.Clear();

            //Program Header
            string titel = "  Zahlenraten  ";
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));

            //cursor position for title
            xTitelPos = (Console.WindowWidth - titel.Length) / 2;
            Console.SetCursorPosition(xTitelPos, 1);
            Console.Write(titel);

            //reset cursor position
            Console.SetCursorPosition(0, 4);
            //set console title
            Console.Title = titel;


            //Eingabe der Daten
            Console.WriteLine($"Ich denke an eine Uahl zwischen {minValue}...{maxValue}:");

            do
            {
                restZeit = versuchsZeit - (DateTime.Now.TimeOfDay - startZeit);

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
                    Console.SetCursorPosition(35, Console.CursorTop-1);
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


            } while (!eingabeIstZahl || anzahlVersuche > 0 && restZeit.Seconds > 0 && zufallsZahl != Ratezahl);

            if (anzahlVersuche >= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nVersuche aufgebraucht: Du hast die Zahl {zufallsZahl} leider nicht erraten..... :( ");
                Console.ResetColor();
            }
            else if (restZeit.Seconds > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nZeit abgelaufen: Du hast die Zahl {zufallsZahl} leider nicht erraten..... :( ");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\ndu hast die Zahl {zufallsZahl} erraten!!!!");
                Console.ResetColor();
            }

        }
    }
}
