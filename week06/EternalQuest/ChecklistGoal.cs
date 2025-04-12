public class ChecklistGoal : Goal
{
    private int timesCompleted;
    private int target;

    public ChecklistGoal(string name, int points, int target) : base(name, points)
    {
        this.target = target;
        this.timesCompleted = 0;
    }

    public override void RecordEvent()
    {
        if (!isComplete)
        {
            timesCompleted++;
            int totalPoints = points * timesCompleted;
            if (timesCompleted == target)
            {
                totalPoints += 500; // Bonus on completion
                isComplete = true;
                Console.WriteLine($"Goal {name} completed! You earned {totalPoints} points, including bonus!");
            }
            else
            {
                Console.WriteLine($"You earned {points} points for completing part {timesCompleted}/{target} of {name}. Total: {totalPoints} points.");
            }
        }
    }

    public override string GetGoalStatus()
    {
        return isComplete ? $"[X] {name} (Completed {timesCompleted}/{target})" : $"[ ] {name} (Completed {timesCompleted}/{target})";
    }
}
