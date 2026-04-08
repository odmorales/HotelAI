namespace Hotelia.Domain.Hotels;

public class HotelId
{
    public Guid Value { get; }

    public HotelId()
    {
        Value = Guid.NewGuid();
    }

    public HotelId(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("HotelId cannot be empty.", nameof(value));

        Value = value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not HotelId other)
            return false;

        return Value == other.Value;
    }

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => Value.ToString();
}
