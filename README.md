```mermaid
classDiagram
    User --> Role
    Activity --> User
    Activity --> Platform
    Activity --> ActivityRegistration
    ActivityRegistration --> StatusEnum
    Activity --> CreateActivityEvent
    Activity --> UserRegistrationEvent
    Activity --> UserUnregistrationEvent
    ActivityPlan <-- Activity
    Platform ..|> User
    Region <-- City
    Country <-- Region
    City <-- Platform
    Coordinat <-- Platform

    class Role{
        Id
        Title
    }

    class User{
        Guid Id
        string Name
        string SecondName
        Email Email
        string Password
        byte[] PasswordSalt
        List~Role~ Roles
    }

    class Activity{
        Guid Id
        string Title
        string Description
        DateTimeOfSet ActivityStartTime
        Guid PlatformId
        Guid CityId
        List~ActivityRegistration~ ActivityRegistrations 
        List~ActivityPlan~ Plans
    }

    class Platform{
        Guid Id
        Guid LandlordId
        string Title
        string Description
        Coordinat Adress
        Guid CityId
        int Capacity
    }

    class ActivityRegistration{
        Guid ActivityId
        Guid UserId
        Status Status
    }

    class StatusEnum{
        None,
        Reminder, 
        RegistrationConfirmation,
        Rejected
    }

    class ActivityPlan{
        string Title
        string Description
        DateTimeOfSet TimeEdit
    }

    class Country{
        Guid Id
        string Title
    }

    class Region{
        Guid Id
        string Title
        Guid CountryId
    }

    class City{
        Guid Id
        string Title
        Guid CountryId
        Guid RegionId
    }

    class Coordinat{
        string Width
        string Longitude
    }
```
