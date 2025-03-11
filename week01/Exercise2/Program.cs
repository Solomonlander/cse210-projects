using System;

class Program
{
    static void Main(string[] args)
    {
        // Step 1: 
        Console.Write("Enter your grade percentage: ");
        string userInput = Console.ReadLine();
        int gradePercentage;

        // Try to convert user input into an integer
        if (!int.TryParse(userInput, out gradePercentage))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        // Step 2: 
        string letter = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Step 3: 
        Console.WriteLine($"Your grade is: {letter}");

        // Step 4: 
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't worry, keep trying! You can do it next time.");
        }
    }
}
