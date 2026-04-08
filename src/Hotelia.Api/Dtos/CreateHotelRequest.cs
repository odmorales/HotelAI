namespace Hotelia.Api.Dtos;

public class CreateHotelRequest
{
    public string Name { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? Description { get; set; }
}
