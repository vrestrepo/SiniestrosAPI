namespace Domain.Entities;

public class Accident
{
    public Guid Id { get; private set; }
    public DateTime OccurredAt { get; private set; }
    public string Department { get; private set; }
    public string City { get; private set; }
    public string AccidentType { get; private set; }
    public List<AccidentVehicle> AccidentVehicles { get; private set; }
    public int Victims { get; private set; }
    public string? Description { get; private set; }

    public Accident(
        Guid id,
        DateTime occurredAt,
        string department,
        string city,
        string accidentType,
        List<AccidentVehicle> accidentVehicles,
        int victims,
        string? description)
    {
        if (string.IsNullOrWhiteSpace(department)) throw new ArgumentException();
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException();
        if (string.IsNullOrWhiteSpace(accidentType)) throw new ArgumentException();
        if (accidentVehicles == null || accidentVehicles.Count == 0) throw new ArgumentException();
        if (victims < 0) throw new ArgumentException();

        Id = id;
        OccurredAt = occurredAt;
        Department = department;
        City = city;
        AccidentType = accidentType;
        AccidentVehicles = accidentVehicles;
        Victims = victims;
        Description = description;
    }
}