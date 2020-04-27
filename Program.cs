using System;
using System.Collections.Generic;
using System.Linq;
using Word_Unscrambler.Data;

namespace Word_Unscrambler
{
    class Program
    {
        private const string wordListFileName = "Wordlist.txt";
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();

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
                        Console.WriteLine("Enter your scrambled words (Separated by comma): ");
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
                    continueDecision = Console.ReadLine() ?? string.Empty;
                } while (!continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) &&
                         !continueDecision.Equals("N", StringComparison.OrdinalIgnoreCase));

                if (continueDecision == "N" || continueDecision == "n")
                {
                    Environment.Exit(0);
                }


            } while (continueApp);

        }
        private static void ExecuteManualScrambledWordsMethod()
        {
            var manualWords = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualWords.Split(',');
            DisplayMatchedUnscrambledWords(scrambledWords);
        }
        private static void ExecuteScrambledFileMethod()
        {
            try
            {
                var filename = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = fileReader.Read(filename);
                DisplayMatchedUnscrambledWords(scrambledWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            string[] wordList = fileReader.Read(wordListFileName);

            List<MatchedWords> matchedWords = wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine("Match found for {0}: {1}", matchedWord.scrambledWords, matchedWord.Word);
                }

            } else
            {
                Console.WriteLine("No matches found.");
            }

        }
    }
}
