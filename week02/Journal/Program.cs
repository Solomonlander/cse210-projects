public class JournalProgram
{
    private static Journal journal = new Journal();
    private static PromptGenerator promptGenerator = new PromptGenerator();

    public static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to a file");
            Console.WriteLine("4. Load journal from a file");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    SaveJournal();
                    break;
                case "4":
                    LoadJournal();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void WriteEntry()
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        JournalEntry entry = new JournalEntry(prompt, response);
        journal.AddEntry(entry);
        Console.WriteLine("Entry added successfully!");
    }

    private static void SaveJournal()
    {
        Console.Write("Enter filename to save journal: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
        Console.WriteLine("Journal saved successfully!");
    }

    private static void LoadJournal()
    {
        Console.Write("Enter filename to load journal: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
        Console.WriteLine("Journal loaded successfully!");
    }
}