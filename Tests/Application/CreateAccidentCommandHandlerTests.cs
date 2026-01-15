using Application.Accidents.Commands;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace Tests.Application;

public class CreateAccidentCommandHandlerTests
{
    private readonly Mock<IAccidentRepository> _repositoryMock;
    private readonly CreateAccidentCommandHandler _handler;

    public CreateAccidentCommandHandlerTests()
    {
        _repositoryMock = new Mock<IAccidentRepository>();
        _handler = new CreateAccidentCommandHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Create_Accident()
    {
        var command = new CreateAccidentCommand(
            DateTime.UtcNow,
            "Caldas",
            "Manizales",
            "Collision",
            new List<VehicleDto>
            {
                new("ABC123", "123456")
            },
            1,
            "Notas de prueba"
        );

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().NotBe(Guid.Empty);
        _repositoryMock.Verify(x => x.AddAsync(It.IsAny<Accident>()), Times.Once);
    }

    [Fact]
    public async Task Handle_Should_Throw_When_No_Vehicles()
    {
        var command = new CreateAccidentCommand(
            DateTime.UtcNow,
            "Caldas",
            "Manizales",
            "Collision",
            new List<VehicleDto>(),
            1,
            null
        );

        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        await act.Should().ThrowAsync<ArgumentException>();
    }
}
