using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Program
    {
        //Define object to access different method
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            //Bool for -> While loop
            bool next = true;
            while (next)
            {
                bool valid = false;
                while (!valid)
                {
                    Console.WriteLine("Enter scrambled word(s) manually or as a file: F - file / M - manual");

                    String option = Console.ReadLine() ?? throw new Exception("String is empty");

                    switch (option.ToUpper())
                    {
                        case "F":
                            Console.WriteLine("Enter full path including the file name: ");
                            valid = true;
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case "M":
                            Console.WriteLine("Enter word(s) manually (separated by commas if multiple): ");
                            valid = true;
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            Console.WriteLine("The entered option was not recognized. Enter a valid option.");
                            break;
                    }

                    //Console.ReadLine();
                }
                valid = false;
                while (!valid)
                {
                    Console.WriteLine("Would you like to continue? Y/N");
                    String option2 = Console.ReadLine() ?? throw new Exception("String is empty");
                    switch (option2.ToUpper())
                    {
                        case "Y":
                            next = true;
                            valid = true;
                            break;
                        case "N":
                            next = false;
                            valid = true;
                            break;
                        default:
                            Console.WriteLine("The entered option was not recognized. Enter a valid option.");
                            break;
                    }
                }
            }
            /*
            catch (Exception ex)
            {
                Console.WriteLine("The program will be terminated. " + ex.Message);

            }*/
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            var filename = Console.ReadLine();
            string[] scrambledWords = _fileReader.Read(filename);
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            string scrambledWords = Console.ReadLine();
            char[] separators = new char[] { ' ', ',' };
            string[] scrambledList = scrambledWords.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            DisplayMatchedUnscrambledWords(scrambledList);
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            //read the list of words from the system file. 
            //string[] wordList = _fileReader.Read("wordlist.txt");

            //Use constants instead
            string[] wordList = new string[] { Constants.s1, Constants.s2, Constants.s3, Constants.s4, Constants.s5, Constants.s6 };

            //call a word matcher method to get a list of structs of matched words.
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            foreach (var matchedWord in matchedWords)
            {
                Console.WriteLine("MATCH FOUND for " + matchedWord.ScrambledWord + " : " + matchedWord.Word);
            }
        }
    }
}
