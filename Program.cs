using System;
using System.Collections.Generic;
using System.Linq;

namespace Word_Unscrambler
{
    class Program
    {
        static void Main(string[] args)
        {

            bool continueApp = true;

            do
            {
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Do you want to unscramble manually inputted words or use a file? M/F");
                var option = Console.ReadLine() ?? string.Empty;

                switch (option.ToUpper())
                {
                    case "M":
                        Console.WriteLine("Enter your scrambled words: ");
                        ExecuteManualScrambledWordsMethod();
                        break;
                    case "F":
                        Console.WriteLine("Enter your file name: ");
                        ExecuteScrambledFileMethod();
                        break;
                    default:
                        Console.WriteLine("Option not recognised, Please try again");
                        break;
                }

                var continueDecision = string.Empty;

                do
                {
                    Console.WriteLine("Do you want to continue? Y/N");
                    continueDecision = (Console.ReadLine() ?? string.Empty);
                } while (!continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) &&
                         !continueDecision.Equals("N", StringComparison.OrdinalIgnoreCase));

                if (continueDecision == "N" || continueDecision == "n")
                {
                    Environment.Exit(0);
                }


            } while (continueApp);

        }

        private static void ExecuteScrambledFileMethod()
        {
            
        }

        private static void ExecuteManualScrambledWordsMethod()
        {
            
        }
    }
}
