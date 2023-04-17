namespace ChumakBank.Persistence.Context;

public sealed class DbSetting
{
    public string Server { get; init; }
    public string Database { get; init; }
    public string UserId { get; init; }
    public string Password { get; init; }

    public override string ToString()
    {
        return $"Host={Server}; Database={Database}; Username={UserId}; Password={Password};";
    }
}