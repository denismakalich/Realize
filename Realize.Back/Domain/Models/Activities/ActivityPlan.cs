namespace Domain.Models.Activities;

public class ActivityPlan
{
    public string Title { get; private init; }
    public string Description { get; private init; }
    public DateTimeOffset StartTime { get; private set; }
    public DateTimeOffset EndTime { get; private set; }

    public ActivityPlan(string title, string description, DateTimeOffset startTime, DateTimeOffset endTime)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("The title cannot be null or whitespace.", nameof(title));
        }


        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("The description cannot be null or whitespace.", nameof(description));
        }
        
        Title = title;
        Description = description;
        StartTime = startTime;
        EndTime = endTime;
    }

    public static ActivityPlan Create(string title, string description, DateTimeOffset startTime, DateTimeOffset endTime)
    {
        return new ActivityPlan(title, description, startTime, endTime);
    }
}