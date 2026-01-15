namespace Domain.Entities;

public class Accident
{
    private readonly List<AccidentVehicle> _accidentVehicles = new();

    public Guid Id { get; private set; }
    public DateTime OccurredAt { get; private set; }
    public string Department { get; private set; }
    public string City { get; private set; }
    public string AccidentType { get; private set; }
    public IReadOnlyCollection<AccidentVehicle> AccidentVehicles => _accidentVehicles;
    public int Victims { get; private set; }
    public string? Description { get; private set; }

    public Accident(
        Guid id,
        DateTime occurredAt,
        string department,
        string city,
        string accidentType,
        int victims,
        string? description)
    {
        if (string.IsNullOrWhiteSpace(department)) throw new ArgumentException();
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException();
        if (string.IsNullOrWhiteSpace(accidentType)) throw new ArgumentException();
        if (victims < 0) throw new ArgumentException();

        Id = id;
        OccurredAt = occurredAt;
        Department = department;
        City = city;
        AccidentType = accidentType;
        Victims = victims;
        Description = description;
    }

    public void AddVehicle(Vehicle vehicle)
    {
        if (vehicle == null) throw new ArgumentException();

        var exists = _accidentVehicles.Any(x => x.VehicleId == vehicle.Id);
        if (exists) return;

        _accidentVehicles.Add(new AccidentVehicle(this, vehicle));
    }
}