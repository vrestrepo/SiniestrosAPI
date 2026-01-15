namespace Application.Accidents.Queries;

public record AccidentDto(
    Guid Id,
    DateTime OccurredAt,
    string Department,
    string City,
    string AccidentType,
    IReadOnlyList<VehicleDto> Vehicles,
    int Victims,
    string? Description
);
