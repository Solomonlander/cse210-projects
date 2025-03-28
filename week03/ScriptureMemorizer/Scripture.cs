using System;
using System.Collections.Generic;

namespace ScriptureMemorization
{
    public class Scripture
    {
        private ScriptureReference _reference;
        private List<Word> _words;

        public Scripture(string reference, string text)
        {
            _reference = new ScriptureReference(reference);
            _words = new List<Word>();

            // split text into words and create Word objects
            foreach (var word in text.Split(' '))
            {
                _words.Add(new Word(word));
            }
        }

        // display scripture with hidden words replaced by underscores
        public void DisplayScripture(bool showAll = false)
        {
            Console.WriteLine(_reference.ToString());

            foreach (var word in _words)
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
            int numWordsToHide = Math.Min(3, _words.Count);

            List<int> indicesToHide = new List<int>();

            // select random words to hide
            while (indicesToHide.Count < numWordsToHide)
            {
                int index = rand.Next(_words.Count);
                if (!indicesToHide.Contains(index) && !_words[index].IsHidden)
                {
                    indicesToHide.Add(index);
                    _words[index].Hide();
                }
            }
        }

        // check if all words are hidden
        public bool AllWordsHidden()
        {
            foreach (var word in _words)
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
            foreach (var word in _words)
            {
                if (word.IsHidden)
                {
                    hiddenCount++;
                }
            }
            Console.WriteLine($"Progress: {hiddenCount} / {_words.Count} words memorized.");
        }
    }
}
