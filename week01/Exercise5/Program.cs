class Program
{
    // function 1: 
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // function 2: 
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // function 3: 
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    // function 4: 
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // function 5: 
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }

    // main method
    static void Main(string[] args)
    {
        
        DisplayWelcome();  // Step 1: display welcome message
        
        string userName = PromptUserName();  // Step 2: get user's name
        int userNumber = PromptUserNumber();  // Step 3: get user's favorite number
        
        int squaredNumber = SquareNumber(userNumber);  // Step 4: square the user's number
        
        DisplayResult(userName, squaredNumber);  // Step 5: display the result
    }
}
