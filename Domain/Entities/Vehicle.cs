namespace Domain.Entities;

public class Vehicle
{
    public Guid Id { get; private set; }
    public string Plate { get; private set; }
    public string OwnerIdentification { get; private set; }

    public Vehicle(Guid id, string plate, string ownerIdentification)
    {
        if (string.IsNullOrWhiteSpace(plate)) throw new ArgumentException();
        if (string.IsNullOrWhiteSpace(ownerIdentification)) throw new ArgumentException();

        Id = id;
        Plate = plate;
        OwnerIdentification = ownerIdentification;
    }
}
