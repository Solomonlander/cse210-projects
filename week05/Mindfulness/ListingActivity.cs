// ListingActivity.cs
public class ListingActivity : Activity
{
    private static string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

    public override void ExecuteActivity()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Pause(3); // Give user time to think

        Console.WriteLine("Start listing items now:");
        int count = 0;

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Enter item: ");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                count++;
            }
        }

        Console.WriteLine($"You listed {count} items.");
    }
}
