// As part of creativity, i have added Random Scripture Selection. Instead of having just one fixed scripture, I added a feature where the program randomly selects scriptures from a predefined list. 
// i have added, Loading Scriptures from a File. This way, the user can add more scriptures to the file, and the program will automatically use them.

using System;
using System.Collections.Generic;
using System.IO;

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

public class Scripture
{
    public ScriptureReference Reference { get; set; }
    public List<Word> Words { get; set; }

    public Scripture(string reference, string text)
    {
        Reference = new ScriptureReference(reference);
        Words = new List<Word>();

        // split text into words and create Word objects
        foreach (var word in text.Split(' '))
        {
            Words.Add(new Word(word));
        }
    }

    // display scripture with hidden words replaced by underscores
    public void DisplayScripture(bool showAll = false)
    {
        Console.WriteLine(Reference.ToString());

        foreach (var word in Words)
        {
            if (showAll || !word.IsHidden)
            {
                Console.Write(word.ToString() + " ");
            }
            else
            {
                Console.Write(new string('_', word.WordText.Length) + " ");
            }
        }
        Console.WriteLine();
    }

    // hide a few random words
    public void HideRandomWords()
    {
        Random rand = new Random();
        int numWordsToHide = Math.Min(3, Words.Count); 

        List<int> indicesToHide = new List<int>();

        // select random words to hide
        while (indicesToHide.Count < numWordsToHide)
        {
            int index = rand.Next(Words.Count);
            if (!indicesToHide.Contains(index) && !Words[index].IsHidden)
            {
                indicesToHide.Add(index);
                Words[index].Hide();
            }
        }
    }

    // check if all words are hidden
    public bool AllWordsHidden()
    {
        foreach (var word in Words)
        {
            if (!word.IsHidden)
            {
                return false;
            }
        }
        return true;
    }

    // display the user's progress 
    public void DisplayProgress()
    {
        int hiddenCount = 0;
        foreach (var word in Words)
        {
            if (word.IsHidden)
            {
                hiddenCount++;
            }
        }
        Console.WriteLine($"Progress: {hiddenCount} / {Words.Count} words memorized.");
    }
}

public class ScriptureReference
{
    public string Reference { get; set; }

    public ScriptureReference(string reference)
    {
        Reference = reference;
    }

    public override string ToString()
    {
        return Reference;
    }
}

public class Word
{
    public string WordText { get; set; }
    public bool IsHidden { get; private set; }

    public Word(string word)
    {
        WordText = word;
        IsHidden = false;
    }

    // hide the word 
    public void Hide()
    {
        IsHidden = true;
    }

    // return the word 
    public override string ToString()
    {
        return IsHidden ? new string('_', WordText.Length) : WordText;
    }
}
