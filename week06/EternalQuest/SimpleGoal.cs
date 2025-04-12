public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        if (!isComplete)
        {
            isComplete = true;
            Console.WriteLine($"Congratulations! You've completed the goal: {name} and earned {points} points.");
        }
    }

    public override string GetGoalStatus()
    {
        return isComplete ? $"[X] {name} (Completed)" : $"[ ] {name} (Not Completed)";
    }
}
