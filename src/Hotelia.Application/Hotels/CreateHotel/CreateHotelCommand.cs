namespace Hotelia.Application.Hotels.CreateHotel;

public class CreateHotelCommand
{
    public string Name { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? Description { get; set; }
}
