using System;
using System.Collections.Generic;

// Base class: Activity
public abstract class Activity
{
    private DateTime activityDate;
    private int durationMinutes;

    public Activity(DateTime date, int duration)
    {
        activityDate = date;
        durationMinutes = duration;
    }

    public DateTime ActivityDate => activityDate;
    public int DurationMinutes => durationMinutes;

    // Abstract methods to be overridden by derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Method to generate summary
    public string GetSummary()
    {
        return $"{ActivityDate:dd MMM yyyy} {this.GetType().Name} ({DurationMinutes} min): " +
               $"Distance {GetDistance():F1}, Speed: {GetSpeed():F1}, Pace: {GetPace():F2} min per unit";
    }
}

// Derived class: Running
public class Running : Activity
{
    private double distance; // Distance in miles

    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;

    public override double GetSpeed() => (distance / DurationMinutes) * 60; // Speed in miles per hour

    public override double GetPace() => DurationMinutes / distance; // Pace in minutes per mile
}

// Derived class: Cycling
public class Cycling : Activity
{
    private double speed; // speed in miles per hour

    public Cycling(DateTime date, int duration, double speed) : base(date, duration)
    {
        this.speed = speed;
    }

    public override double GetDistance() => (speed * DurationMinutes) / 60; // Distance in miles

    public override double GetSpeed() => speed; // Speed is already in miles per hour

    public override double GetPace() => 60 / speed; // Pace in minutes per mile
}

// Derived class: Swimming
public class Swimming : Activity
{
    private int laps; // number of laps in the pool

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        double distanceInKilometers = (laps * 50) / 1000.0;
        return distanceInKilometers * 0.62; // convert to miles
    }

    public override double GetSpeed() => (GetDistance() / DurationMinutes) * 60; 

    public override double GetPace() => DurationMinutes / GetDistance();
}

public class Program
{
    public static void Main()
    {
        // Creating activities
        var activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0), 
            new Cycling(new DateTime(2022, 11, 3), 30, 12.0), 
            new Swimming(new DateTime(2022, 11, 3), 30, 20)  
        };

        // Display summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
