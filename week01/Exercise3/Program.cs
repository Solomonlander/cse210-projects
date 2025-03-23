using System;

class Program
{
    static void Main(string[] args)
    {
        // Step 1: generate a random magic number between 1 and 100
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101); // Generates a number from 1 to 100

        // Step 2: Start a loop to allow multiple guesses
        int guess = -1;
        while (guess != magicNumber)
        {
            // Ask for a guess
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            // Step 3: Give feedback about the guess
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}
