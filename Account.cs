using Ardalis.GuardClauses;

namespace MultipleAssertions;

public class Account
{
    public Account(string name, string number, decimal balance)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
        Number = Guard.Against.NullOrEmpty(number, nameof(number));
        Balance = Guard.Against.NegativeOrZero(balance, nameof(balance));
    }

    public string Name { get; }
    public string Number { get; }
    public decimal Balance { get; }
}
