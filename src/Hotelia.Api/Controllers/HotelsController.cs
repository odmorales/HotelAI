using FluentValidation;
using Hotelia.Api.Dtos;
using Hotelia.Application.Hotels.CreateHotel;
using Microsoft.AspNetCore.Mvc;

namespace Hotelia.Api.Controllers;

[ApiController]
[Route("api/hotels")]
public class HotelsController(CreateHotelCommandHandler createHotelHandler) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CreateHotelResponse>> CreateHotel([FromBody] CreateHotelRequest request,
                                                                     CancellationToken cancellationToken)
    {
        try
        {
            var command = new CreateHotelCommand
            {
                Name = request.Name,
                City = request.City,
                Description = request.Description
            };

            var result = await createHotelHandler.Handle(command, cancellationToken);

            var response = new CreateHotelResponse
            {
                Id = result.Id,
                Name = result.Name,
                City = result.City,
                Description = result.Description,
                IsEnabled = result.IsEnabled
            };

            return CreatedAtAction(nameof(CreateHotel), new { id = response.Id }, response);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors.Select(e => new { field = e.PropertyName, message = e.ErrorMessage }).ToList();
            return BadRequest(new { errors });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                new { message = "An unexpected error occurred." });
        }
    }
}
