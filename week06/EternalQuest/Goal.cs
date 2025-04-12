public abstract class Goal
{
    protected string name;
    protected int points;
    protected bool isComplete;

    public Goal(string name, int points)
    {
        this.name = name;
        this.points = points;
        this.isComplete = false;
    }

    public string Name { get => name; }
    public int Points { get => points; }
    public bool IsComplete { get => isComplete; }

    public abstract void RecordEvent();
    public abstract string GetGoalStatus();
}
