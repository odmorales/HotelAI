using Hotelia.Domain.Hotels;

namespace Hotelia.Application.Hotels.Abstractions;

public interface IHotelRepository
{
    Task<Hotel> AddAsync(Hotel hotel, CancellationToken cancellationToken = default);
}
