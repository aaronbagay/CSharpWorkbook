using System;
using System.IO;

namespace Chapter03.Exercise03
{
    public class CashMachine
    {
        private readonly Action<string> _logger;
        public CashMachine(Action<string> logger)
        {
            _logger = logger;
        }

        private void Log(string message) => _logger?.Invoke(message);

        public void VerifyPin(string pin) => Log($"VerifyPin called : PIN = {pin}");
        public void ShowBalance() =>Log("ShowBalance called= 9999");
    }

    public static class Program
    {
        private const string OutputFile = "activity.txt";
        
        public static void Main()
        {
            if (File.Exists(OutputFile))
            {
                File.Delete(OutputFile);
            }

            Action<string> logger = LogToConsole;

            logger += LogToFile;

            var CashMachine = new CashMachine(logger);

            Console.WriteLine("Enter your PIN:");
            var pin = Console.ReadLine();
            if (string.IsNullOrEmpty(pin))
            {
                Console.WriteLine("No PIN entered");
                return;
            }
            CashMachine.VerifyPin(pin);
            Console.WriteLine();


            Console.WriteLine("Press to enter show balance");
            Console.ReadLine();

            CashMachine.ShowBalance();
            Console.WriteLine("Press Enter to quit");
            Console.ReadLine();


            static void LogToConsole(string message) => Console.WriteLine(message);
            static void LogToFile(string message) => File.AppendAllText(OutputFile, message);
        }
    }
}