using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(JournalEntry entry)
    {
        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry.ToString());
            Console.WriteLine(new string('-', 20));  // Separator for readability
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter file = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                file.WriteLine(entry.FormatForSaving());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();  // Clear current entries
        var lines = File.ReadAllLines(filename);

        foreach (var line in lines)
        {
            var parts = line.Split(" | ");
            if (parts.Length == 3)
            {
                var entry = new JournalEntry(parts[0], parts[1])
                {
                    Date = parts[2]
                };
                entries.Add(entry);
            }
        }
    }
}