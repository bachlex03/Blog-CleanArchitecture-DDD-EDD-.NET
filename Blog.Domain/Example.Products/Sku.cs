public record Sku
{
    private const int DEFAULT_LENGTH = 6;

    private Sku(string value) => Value = value;

    public string Value { get; }

    public static Sku? Create(string value)
    {

        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        if (value.Length != DEFAULT_LENGTH)
        {
            return null;
        }

        return new Sku(value);
    }
}