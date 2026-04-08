using FluentValidation;
using Hotelia.Application.Hotels.Abstractions;
using Hotelia.Domain.Hotels;

namespace Hotelia.Application.Hotels.CreateHotel;

public class CreateHotelCommandHandler(IHotelRepository hotelRepository,
                                      IValidator<CreateHotelCommand> validator)
{
    public async Task<CreateHotelResult> Handle(CreateHotelCommand command,
                                                CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var hotel = Hotel.Create(command.Name, command.City, command.Description);

        var createdHotel = await hotelRepository.AddAsync(hotel, cancellationToken);

        return new CreateHotelResult
        {
            Id = createdHotel.Id.Value,
            Name = createdHotel.Name,
            City = createdHotel.City,
            Description = createdHotel.Description,
            IsEnabled = createdHotel.IsEnabled
        };
    }
}
