using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using Domain.Exceptions;

namespace Domain.Models.Users;

public sealed class Account : EntityWithEvents
{
    public Guid Id { get; private init; }
    public string? Email { get; private set; }
    public string? NormalizedEmail { get; private set; }
    public DateTime CreatedDate { get; private init; }
    public DateTime UpdatedDate { get; private set; }
    public IReadOnlyCollection<byte>? Salt { get; private set; }
    public IReadOnlyCollection<byte>? PasswordHash { get; private set; }

    public Account(Guid id, string email, string password)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(email));
        }

        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(password));
        }

        SetEmail(email);
        SetPassword(password);

        CreatedDate = UpdatedDate = DateTime.UtcNow;
    }

    public static Account Create(string email, string password)
    {
        Guid Id = Guid.NewGuid();

        return new Account(Id, email, password);
    }

    [MemberNotNullWhen(true, nameof(NormalizedEmail))]
    [MemberNotNullWhen(true, nameof(Salt))]
    [MemberNotNullWhen(true, nameof(PasswordHash))]
    public bool IsEmailAuthorization()
    {
        return NormalizedEmail is not null && Salt is not null && PasswordHash is not null;
    }

    [MemberNotNull(nameof(NormalizedEmail))]
    [MemberNotNull(nameof(Salt))]
    [MemberNotNull(nameof(PasswordHash))]
    public void AddEmailAuthorization(string email, string password)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(email));
        }

        if (!string.IsNullOrEmpty(NormalizedEmail) && NormalizedEmail != email.ToUpperInvariant())
        {
            throw new ArgumentException("Email does not match.", nameof(email));
        }

        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(password));
        }

        ThrowIfNotEmailAuthorization();

        if (NormalizedEmail is null)
        {
            SetEmail(email);
        }

        SetPassword(password);
        SetUpdatedDate();
    }

    public bool VerifyByPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(password));
        }

        ThrowIfNotEmailAuthorization();

        using (var hmac = new HMACSHA512((byte[])Salt))
        {
            var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            var a = hmac.ComputeHash(passwordHash);

            var passwordHashArray = (byte[])PasswordHash;
            var b = hmac.ComputeHash(passwordHashArray);
            return Xor(a, b) && Xor(passwordHash, passwordHashArray);
        }
    }

    public void ChangePassword(string currentPassword, string newPassword)
    {
        if (string.IsNullOrEmpty(newPassword))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(newPassword));
        }

        if (VerifyByPassword(currentPassword))
        {
            throw new AccountException("Password incorrect");
        }

        SetPassword(newPassword);
        SetUpdatedDate();
    }

    [MemberNotNull(nameof(Salt))]
    [MemberNotNull(nameof(PasswordHash))]
    private void SetPassword(string newPassword)
    {
        using (var hmac = new HMACSHA512())
        {
            Salt = hmac.Key;
            PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(newPassword));
        }
    }

    [MemberNotNull(nameof(NormalizedEmail))]
    private void SetEmail(string email)
    {
        ThrowIfEmailIsNotValid(email);

        Email = email;
        NormalizedEmail = email.ToUpperInvariant();
    }

    [MemberNotNull(nameof(NormalizedEmail))]
    [MemberNotNull(nameof(Salt))]
    [MemberNotNull(nameof(PasswordHash))]
    private void ThrowIfNotEmailAuthorization()
    {
        if (!IsEmailAuthorization())
        {
            throw new InvalidOperationException("Not supported email authorization.");
        }
    }

    private static void ThrowIfEmailIsNotValid(string email)
    {
        if (!email.Contains('@', StringComparison.InvariantCultureIgnoreCase)
            || email[^1] == '@'
            || email[0] == '@')
        {
            throw new InvalidOperationException("Invalid email.");
        }
    }

    private void SetUpdatedDate()
    {
        UpdatedDate = DateTime.UtcNow;
    }

    private static bool Xor(byte[] a, byte[] b)
    {
        var x = a.Length ^ b.Length;

        for (var i = 0; i < a.Length && i < b.Length; ++i)
        {
            x |= a[i] ^ b[i];
        }

        return x == 0;
    }
}