namespace Domain.Models.Activities;

public class ActivityPlan
{
    public string Title { get; private init; }
    public string Description { get; private init; }
    public DateTimeOffset TimeEdit { get; private init; }

    public ActivityPlan(string title, string description)
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
        TimeEdit = DateTimeOffset.Now;
    }

    public static ActivityPlan Create(string title, string description)
    {
        return new ActivityPlan(title, description);
    }
}