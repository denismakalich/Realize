using System.Diagnostics.CodeAnalysis;

namespace Domain.Models.Locations;

public class City
{
    public Guid Id { get; private init; }
    public string Title { get; private set; }
    public Guid CountryId { get; private set; }
    public Guid? RegionId { get; private set; }

    public City(Guid id, string title, Guid countryId, Guid regionId)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("The title cannot be null or whitespace.", nameof(title));
        }

        Id = id;
        SetTitle(title);
        SetCountry(countryId);
        SetRegion(regionId);
    }

    [MemberNotNull]
    public void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("The title cannot be null or whitespace.", nameof(title));
        }

        Title = title;
    }

    public void SetCountry(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        CountryId = id;
    }

    public void SetRegion(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        RegionId = id;
    }
}