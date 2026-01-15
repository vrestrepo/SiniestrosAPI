using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Accidents.Commands;

public class CreateAccidentCommandHandler : IRequestHandler<CreateAccidentCommand, Guid>
{
    private readonly IAccidentRepository _repository;

    public CreateAccidentCommandHandler(IAccidentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateAccidentCommand request, CancellationToken cancellationToken)
    {
        if (request.Vehicles == null || request.Vehicles.Count == 0)
            throw new ArgumentException("At least one vehicle is required");

        var accident = new Accident(
            Guid.NewGuid(),
            request.OccurredAt,
            request.Department,
            request.City,
            request.AccidentType,
            request.Victims,
            request.Description
        );

        foreach (var v in request.Vehicles)
        {
            var vehicle = new Vehicle(
                Guid.NewGuid(),
                v.Plate,
                v.OwnerIdentification);

            accident.AddVehicle(vehicle);
        }

        await _repository.AddAsync(accident);
        return accident.Id;
    }
}