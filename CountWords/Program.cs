using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CountWords
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read hard coded value ---> enable the below line of code  
            //string filename = "Go do that thing that you do so well";

            // Read a file from C drive (Remember to create file first)
            string filename = @"C:\Data\File.txt";
           
            string inputString = File.ReadAllText(filename);

            // Convert our input to lowercase
            inputString = inputString.ToLower();

            // Define characters to strip from the input and do it
            string[] stripChars = { ";", ",", ".", "-", "_", "^", "(", ")", "[", "]",
                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "\n", "\t", "\r" };
            foreach (string character in stripChars)
            {
                inputString = inputString.Replace(character, "");
            }

            // Split on spaces into a List of strings
            List<string> wordList = inputString.Split(' ').ToList();
          
            // Create a new Dictionary object
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            // Loop over all over the words in our wordList...
            foreach (string word in wordList)
            {
                // If the length of the word is at least three letters...
                if (word.Length >= 0)
                {
                    // ...check if the dictionary already has the word.
                    if (dictionary.ContainsKey(word))
                    {
                        // If we already have the word in the dictionary, increment the count of how many times it appears
                        dictionary[word]++;
                    }
                    else
                    {
                        // Otherwise, if it's a new word then add it to the dictionary with an initial count of 1
                        dictionary[word] = 1;
                    }
                } 
            }

            foreach (var dic in dictionary)
            {
                Console.WriteLine(dic.Value + ":" + dic.Key);
            }

            // Wait for the user to press a key before exiting
            Console.ReadKey();

        }
    }
}
