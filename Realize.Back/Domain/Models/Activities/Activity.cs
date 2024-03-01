using Domain.Models.Enums;
using Domain.Models.Users;

namespace Domain.Models.Activities;

public class Activity
{
    public Guid Id { get; private init; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTimeOffset ActivityStartTime { get; private set; }
    public RegistrationStatus Status { get; private set; } = RegistrationStatus.Reminder;
    public Guid PlatformId { get; private set; }
    public Guid CityId { get; private set; }
    private List<ActivityRegistration> ActivityRegistrations { get; }
    private List<ActivityPlan> ActivityPlans { get; }

    public Activity(
        Guid id,
        string title,
        string description,
        DateTimeOffset activityStartTime,
        Guid platformId,
        Guid cityId,
        List<ActivityRegistration> activityRegistrations,
        List<ActivityPlan> activityPlans)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        Id = id;
        SetTitle(title);
        SetDescription(description);
        SetActivityStartTime(activityStartTime);
        SetPlatform(platformId);
        SetCity(cityId);
        ActivityRegistrations = activityRegistrations;
        ActivityPlans = activityPlans;
    }

    public static Activity Create(
        string title,
        string description,
        DateTimeOffset activityStartTime,
        Guid platformId,
        Guid cityId)
    {
        Guid id = Guid.NewGuid();

        var activity = new Activity(
            id,
            title,
            description,
            activityStartTime,
            platformId,
            cityId,
            new List<ActivityRegistration>(),
            new List<ActivityPlan>());

        return activity;
    }

    public void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("The title cannot be null or whitespace.", nameof(title));
        }

        Title = title;
    }

    public void SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("The description cannot be null or whitespace.", nameof(description));
        }

        Description = description;
    }

    public void SetActivityStartTime(DateTimeOffset startTime)
    {
        ArgumentNullException.ThrowIfNull(startTime);

        ActivityStartTime = startTime;
    }

    public void SetPlatform(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        PlatformId = id;
    }

    public void SetCity(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        CityId = id;
    }

    public void AddRegistration(User user) => ActivityRegistrations.Add(ActivityRegistration.Create(this, user));

    public void SetConfirm(User user)
        => ActivityRegistrations.Single(x => x.UserId == user.Id).SetStatus(RegistrationStatus.Confirm);

    public void SetReject(User user)
        => ActivityRegistrations.Single(x => x.UserId == user.Id).SetStatus(RegistrationStatus.Rejected);
}