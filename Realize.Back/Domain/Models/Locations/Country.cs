using System.Diagnostics.CodeAnalysis;

namespace Domain.Models.Locations;

public class Country
{
    public Guid Id { get; private init; }
    public string Title { get; private set; }

    public Country(Guid id, string title)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        Id = id;
        SetTitle(title);
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
}