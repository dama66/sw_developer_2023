using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Console.WriteLine("Applikation läuft...");

            var cancellationToken = ExecuteBackgroundAction(UdpateDateTime);
            cancellationToken.Token.Register(CancelTokenCancelled);
            
            do
            {
                Console.Write("Cancel (j/n): ");
                input = Console.ReadLine();
            }
            while (input.ToLower() != "j");

            Console.WriteLine("Prozess wird abgebrochen..");
            cancellationToken.Cancel();            

            Console.ReadLine();            
        }

        private static void CancelTokenCancelled()
        {
            Console.WriteLine("Cancellation Token wurde nun ausgelöst...");
        }

        private static void UdpateDateTime(CancellationToken cancellationToken)
        {
            int oldXPosition = 0;
            int oldYPosition = 0;

            do
            {
                oldXPosition = Console.CursorLeft;
                oldYPosition = Console.CursorTop;

                Console.SetCursorPosition(Console.WindowWidth - 20, 0);
                Console.WriteLine(DateTime.Now);

                Console.SetCursorPosition(oldXPosition, oldYPosition);
                Thread.Sleep(1000);                
            }
            while (!cancellationToken.IsCancellationRequested);

        }

        private static CancellationTokenSource ExecuteBackgroundAction(Action<CancellationToken> action)
        {
            var tokenSource = new CancellationTokenSource();

            Task.Run(() => 
            { 
                action(tokenSource.Token); 
            });

            return tokenSource;
        }
    }
}
