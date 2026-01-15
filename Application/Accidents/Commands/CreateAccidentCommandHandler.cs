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
            throw new ArgumentException();

        var accidentId = Guid.NewGuid();

        var accident = new Accident(
            accidentId,
            request.OccurredAt,
            request.Department,
            request.City,
            request.AccidentType,
            new List<AccidentVehicle>(),
            request.Victims,
            request.Description
        );

        foreach (var v in request.Vehicles)
        {
            var vehicle = new Vehicle(Guid.NewGuid(), v.Plate, v.OwnerIdentification);
            accident.AccidentVehicles.Add(new AccidentVehicle(accident, vehicle));
        }

        if (accident.AccidentVehicles.Count == 0)
            throw new ArgumentException();

        await _repository.AddAsync(accident);
        return accident.Id;
    }
}
