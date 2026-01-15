using MediatR;

namespace Application.Accidents.Commands;

public record CreateAccidentCommand(
    DateTime OccurredAt,
    string Department,
    string City,
    string AccidentType,
    List<VehicleDto> Vehicles,
    int Victims,
    string? Description
) : IRequest<Guid>;
