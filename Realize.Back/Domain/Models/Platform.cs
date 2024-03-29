using Domain.Models.Locations;

namespace Domain.Models;

public class Platform
{
    public Guid Id { get; private init; }
    public Guid LandlordId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public GeoPoint Adress { get; private set; }
    public Guid CityId { get; private set; }
    public int Capacity { get; private set; }

    public Platform(Guid id, Guid landlordId, string title, string description, GeoPoint adress, Guid cityId,
        int capacity)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        Id = id;
        SetLandlord(landlordId);
        SetTitle(title);
        SetDescription(description);
        SetAdress(adress);
        SetCity(cityId);
        SetCapacity(capacity);
    }

    public Platform Create(Guid landlordId, string title, string description, GeoPoint adress, Guid cityId,
        int capacity)
    {
        Guid id = Guid.NewGuid();

        return new Platform(id, landlordId, title, description, adress, cityId, capacity);
    }

    public void SetLandlord(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        LandlordId = id;
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

    public void SetAdress(GeoPoint adress)
    {
        ArgumentNullException.ThrowIfNull(adress);

        Adress = adress;
    }

    public void SetCity(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        CityId = id;
    }

    public void SetCapacity(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("The capacity must be more then 0", nameof(capacity));

        Capacity = capacity;
    }
}