using Domain.Exceptions;
using Domain.Models.Enums;
using Domain.Models.Users;

namespace Domain.Models.Activities;

public class ActivityRegistration
{
    public Guid ActivityId { get; private init; }
    public Guid UserId { get; private set; }
    public RegistrationStatus Status { get; private set; }

    public ActivityRegistration(Guid activityId, Guid userId, RegistrationStatus status)
    {
        if (activityId == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(activityId));
        }

        if (userId == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(userId));
        }

        UserId = userId;
        ActivityId = activityId;
        SetStatus(status);
    }

    public static ActivityRegistration Create(Activity activity, User user)
    {
        return new ActivityRegistration(activity.Id, user.Id, activity.Status);
    }

    public void SetStatus(RegistrationStatus registrationStatus)
    {
        if (registrationStatus != RegistrationStatus.Reminder)
            throw new StatusException("Status will be reminder");

        Status = registrationStatus;
    }
}