using Domain.Models.Enums;

namespace Domain.Models.Activities;

public class ActivityRegistration
{
    public Guid ActivityId { get; private init; }
    public Guid UserId { get; private init; }
    public StatusEnum Status { get; private set; }

    public ActivityRegistration(Guid activityId, Guid userId, StatusEnum status)
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

    public static ActivityRegistration Create(Guid activityId, Guid userId, StatusEnum status = StatusEnum.None)
    {
        return new ActivityRegistration(activityId, userId, status);
    }

    public void SetStatus(StatusEnum status = StatusEnum.Rejected) => Status = status;
}