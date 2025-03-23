using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt and read user's first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Prompt and read user's last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Output the formatted name
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
