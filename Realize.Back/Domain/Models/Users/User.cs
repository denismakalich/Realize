namespace Domain.Models.Users;

public class User
{
    public Guid Id { get; private init; }
    public string Name { get; private set; }
    public string SecondName { get; private set; }
    public Account Account { get; private init; }

    public User(
        Guid id,
        string name,
        string secondName,
        Account account)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        Id = id;
        SetName(name);
        SetSecondName(secondName);
        Account = account;
    }

    public User Create(string name, string secondName, Account account)
    {
        Guid id = Guid.NewGuid();

        return new User(id, name, secondName, account);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("The name cannot be null or whitespace.", nameof(name));
        }

        Name = name;
    }

    public void SetSecondName(string secondName)
    {
        if (string.IsNullOrWhiteSpace(secondName))
        {
            throw new ArgumentException("The name cannot be null or whitespace.", nameof(secondName));
        }

        SecondName = secondName;
    }
}