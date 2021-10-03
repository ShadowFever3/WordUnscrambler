using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            bool matchFound = false;
            List<MatchedWord> matchedWords = new List<MatchedWord>();


            //NEED TO BE REDONE

            foreach (var scrambledWord in scrambledWords)
            {
                foreach (var word in wordList)
                {
                    //scrambledWord already matches word
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                        matchFound = true;
                    }
                    else //other comparisons
                    {
                        char[] scramble = scrambledWord.ToArray();
                        char[] words = word.ToArray();

                        Array.Sort(scramble);
                        Array.Sort(words);

                        string sortedScramble = new string(scramble);
                        string sortedWords = new string(words);
                        if (sortedScramble.Equals(sortedWords, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                            matchFound = true;
                        }
                    }
                    
                }
            }

            //if no match was found, notify user
            if (!matchFound)
            {
                Console.WriteLine("No match was found.");
            }

            MatchedWord BuildMatchedWord(string scrambledWord, string word)
            {
                MatchedWord matchedWord = new MatchedWord
                {
                    ScrambledWord = scrambledWord,
                    Word = word
                };

                return matchedWord;
            }

            return matchedWords;
        } 
    }

}
