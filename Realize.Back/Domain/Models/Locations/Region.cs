using System.Diagnostics.CodeAnalysis;

namespace Domain.Models.Locations;

public class Region
{
    public Guid Id { get; private init; }
    public string Title { get; private set; }
    public Guid CountryId { get; private set; }

    public Region(Guid id, string title, Guid countryId)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        Id = id;
        SetTitle(title);
        SetCountry(CountryId);
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
}