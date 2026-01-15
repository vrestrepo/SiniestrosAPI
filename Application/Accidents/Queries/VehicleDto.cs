namespace Application.Accidents.Queries;

public record VehicleDto(
    Guid Id,
    string Plate,
    string OwnerIdentification
);
