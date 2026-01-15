using Domain.Entities;
using FluentAssertions;

namespace Tests.Domain;

public class AccidentTests
{
    [Fact]
    public void Constructor_Should_Create_Valid_Accident()
    {
        var accident = new Accident(
            Guid.NewGuid(),
            DateTime.UtcNow,
            "Caldas",
            "Manizales",
            "Collision",
            1,
            "Test"
        );

        accident.Department.Should().Be("Caldas");
        accident.City.Should().Be("Manizales");
        accident.Victims.Should().Be(1);
    }

    [Fact]
    public void Constructor_Should_Throw_When_Department_Is_Empty()
    {
        Action act = () => new Accident(
            Guid.NewGuid(),
            DateTime.UtcNow,
            "",
            "Manizales",
            "Collision",
            1,
            null
        );

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void AddVehicle_Should_Add_Vehicle_To_Accident()
    {
        var accident = new Accident(
            Guid.NewGuid(),
            DateTime.UtcNow,
            "Caldas",
            "Manizales",
            "Collision",
            1,
            null
        );

        var vehicle = new Vehicle(
            Guid.NewGuid(),
            "ABC123",
            "123456"
        );

        accident.AddVehicle(vehicle);

        accident.AccidentVehicles.Should().HaveCount(1);
    }

    [Fact]
    public void AddVehicle_Should_Not_Duplicate_Vehicle()
    {
        var accident = new Accident(
            Guid.NewGuid(),
            DateTime.UtcNow,
            "Caldas",
            "Manizales",
            "Collision",
            1,
            null
        );

        var vehicle = new Vehicle(
            Guid.NewGuid(),
            "ABC123",
            "123456"
        );

        accident.AddVehicle(vehicle);
        accident.AddVehicle(vehicle);

        accident.AccidentVehicles.Should().HaveCount(1);
    }
}
