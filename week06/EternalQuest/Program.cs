public class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int totalScore = 0;

    public static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("Welcome to Eternal Quest!");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Display goals and score");
            Console.WriteLine("4. Exit");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    DisplayGoals();
                    break;
                case "4":
                    running = false;
                    break;
            }
        }
    }

    private static void CreateGoal()
    {
        Console.WriteLine("Enter goal type (simple, eternal, checklist):");
        string type = Console.ReadLine();
        Console.WriteLine("Enter goal name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter points for goal:");
        int points = int.Parse(Console.ReadLine());

        if (type == "simple")
        {
            goals.Add(new SimpleGoal(name, points));
        }
        else if (type == "eternal")
        {
            goals.Add(new EternalGoal(name, points));
        }
        else if (type == "checklist")
        {
            Console.WriteLine("Enter target number of completions:");
            int target = int.Parse(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, points, target));
        }
    }

    private static void RecordEvent()
    {
        Console.WriteLine("Select a goal to record an event for:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        int choice = int.Parse(Console.ReadLine()) - 1;
        if (choice >= 0 && choice < goals.Count)
        {
            goals[choice].RecordEvent();
        }
    }

    private static void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.GetGoalStatus());
        }
    }
}
