namespace Hotelia.Domain.Hotels;

public class Hotel
{
    public HotelId Id { get; private set; } = null!;
    public string Name { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public bool IsEnabled { get; private set; }
    public DateTime CreatedAt { get; private set; }

    // Constructor privado para EF
    private Hotel() { }

    // Factory method
    public static Hotel Create(string name, string city, string? description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Hotel name cannot be empty.", nameof(name));

        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("Hotel city cannot be empty.", nameof(city));

        return new Hotel
        {
            Id = new HotelId(),
            Name = name.Trim(),
            City = city.Trim(),
            Description = description?.Trim(),
            IsEnabled = true,
            CreatedAt = DateTime.UtcNow
        };
    }
}
