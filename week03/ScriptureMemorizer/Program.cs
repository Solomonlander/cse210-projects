// As part of creativity, i have added Random Scripture Selection. Instead of having just one fixed scripture, I added a feature where the program randomly selects scriptures from a predefined list. 
// i have added, Loading Scriptures from a File. This way, the user can add more scriptures to the file, and the program will automatically use them.

using System;
using System.Collections.Generic;
using System.IO;

namespace ScriptureMemorization
{
    class Program
    {
        static void Main(string[] args)
        {
            // load scriptures from a file and select one at random
            List<Scripture> scriptureLibrary = LoadScripturesFromFile("scriptures.txt");
            if (scriptureLibrary.Count == 0)
            {
                Console.WriteLine("No scriptures found in the file. Please check your 'scriptures.txt' file.");
                return;
            }

            Random rand = new Random();
            int randomIndex = rand.Next(scriptureLibrary.Count);
            Scripture scripture = scriptureLibrary[randomIndex];

            // start the memorization process
            while (!scripture.AllWordsHidden())
            {
                Console.Clear();
                scripture.DisplayScripture();
                scripture.DisplayProgress();

                Console.WriteLine("\nPress Enter to hide some words, or type 'quit' to exit.");
                string input = Console.ReadLine();
                
                if (input.ToLower() == "quit")
                {
                    break;
                }

                scripture.HideRandomWords();
            }

            // final display with all words hidden and a review
            Console.Clear();
            scripture.DisplayScripture();
            Console.WriteLine("All words are now hidden. You have completed the scripture memorization!");
            Console.WriteLine("\nReview the scripture (press Enter):");
            Console.ReadLine();
            scripture.DisplayScripture(true); 
        }

        // load scriptures from a file
        static List<Scripture> LoadScripturesFromFile(string fileName)
        {
            List<Scripture> scriptures = new List<Scripture>();

            try
            {
                if (!File.Exists(fileName))
                {
                    Console.WriteLine($"Error: File '{fileName}' not found.");
                    return scriptures;
                }

                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        string reference = parts[0].Trim();
                        string text = parts[1].Trim();
                        scriptures.Add(new Scripture(reference, text));
                    }
                    else
                    {
                        Console.WriteLine($"Skipping invalid scripture line: {line}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading scripture file: " + ex.Message);
            }

            return scriptures;
        }
    }
}
