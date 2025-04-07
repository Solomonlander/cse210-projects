// Activity.cs
public abstract class Activity
{
    protected int duration;
    protected string activityName;
    protected string activityDescription;

    public Activity(string name, string description)
    {
        activityName = name;
        activityDescription = description;
    }

    public virtual void StartActivity()
    {
        Console.WriteLine($"Starting {activityName}");
        Console.WriteLine(activityDescription);
        Console.WriteLine("Please enter the duration of the activity in seconds:");
        duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Prepare to start...");
        Pause(3); // Pause for a few seconds before starting
    }

    public virtual void EndActivity()
    {
        Console.WriteLine($"Well done! You completed the {activityName} activity.");
        Console.WriteLine($"You spent {duration} seconds on this activity.");
        Pause(3); // Pause for a few seconds before ending
    }

    public void Pause(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Clear();
            Console.WriteLine($"Pausing for {seconds - i} seconds...");
            Thread.Sleep(1000); // Wait 1 second
        }
    }

    public abstract void ExecuteActivity(); // To be implemented by derived classes
}
