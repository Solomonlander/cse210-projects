// BreathingActivity.cs
public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    public override void ExecuteActivity()
    {
        Console.WriteLine("Starting breathing activity...");
        for (int i = 0; i < duration / 4; i++) // 4 seconds per cycle (2 for breathing in, 2 for breathing out)
        {
            Console.WriteLine("Breathe in...");
            Pause(2); // Pause for 2 seconds
            Console.WriteLine("Breathe out...");
            Pause(2); // Pause for 2 seconds
        }
    }
}
