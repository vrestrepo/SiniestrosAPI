namespace Domain.Entities;

public class AccidentVehicle
{
    public Guid AccidentId { get; private set; }
    public Accident Accident { get; private set; }
    public Guid VehicleId { get; private set; }
    public Vehicle Vehicle { get; private set; }

    public AccidentVehicle(Accident accident, Vehicle vehicle)
    {
        Accident = accident ?? throw new ArgumentException();
        Vehicle = vehicle ?? throw new ArgumentException();
        AccidentId = accident.Id;
        VehicleId = vehicle.Id;
    }
}