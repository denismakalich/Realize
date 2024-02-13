#InfoTable.png

classDiagram
    User --> RoleEnum
    
    Event --> User
    Event --> Platform
    Event --> EventRegistration
    EventRegistration --> StatusEnum
    Event --> CreateEventEvent
    Event --> UserRegistrationEvent
    Event --> UserUnregistrationEvent
    EventPlan <-- Event

    Notification --> NotificationEnum

    class RoleEnum{
        None
        Organisator
        Landlord
        Company
    }

    class User{
        Guid Id
        string Name
        string SecondName
        Email Email
        string Password
        List Roles
        List PhotoUrl
    }

    class Event{
        Guid Id
        string Title
        string Description
        DateTime EventStartTime
        Guid PlatformId
        List EventRegistration
        List EventPlan
        List PhotoUrl
    }

    class Platform{
        Guid Id
        Guid LandlordId
        string Title
        string Description
        string Adress
        int Capacity
        List PhotoUrl
    }

    class EventRegistration{
        Guid Id
        Guid EventId
        Guid UserId
        Status Status
    }

    class StatusEnum{
        None,
        Reminder, 
        RegistrationConfirmation,
        Rejected
    }

    class Notification{
        NotificationEnum NotificationEnum
        string Text
        DateTime SendTime
    }

    class NotificationEnum{
        None,
        Reminder,
        ConfirmationOfRegistration,
        EventCancellation,
        ChangeOfSchedule,
        InvitationToAnEvent
    }

    class EventPlan{
        string Title
        string Description
        DateTime TimeEdit
    }
