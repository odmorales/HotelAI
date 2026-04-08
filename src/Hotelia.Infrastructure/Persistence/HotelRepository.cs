using Hotelia.Application.Hotels.Abstractions;
using Hotelia.Domain.Hotels;

namespace Hotelia.Infrastructure.Persistence;

public class HotelRepository(HotelDbContext context) : IHotelRepository
{
    public async Task<Hotel> AddAsync(Hotel hotel,
                                      CancellationToken cancellationToken = default)
    {
        await context.Hotels.AddAsync(hotel, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return hotel;
    }
}
