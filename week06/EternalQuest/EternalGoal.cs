public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        if (!isComplete)
        {
            Console.WriteLine($"You recorded an event for {name} and earned {points} points.");
        }
    }

    public override string GetGoalStatus()
    {
        return $"[ ] {name} (Eternal Goal)";
    }
}
