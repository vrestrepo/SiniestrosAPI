using Application.Accidents.Commands;
using Swashbuckle.AspNetCore.Filters;

namespace SiniestrosAPI.Swagger.Examples;

public class CreateAccidentCommandExample
    : IExamplesProvider<CreateAccidentCommand>
{
    public CreateAccidentCommand GetExamples()
    {
        return new CreateAccidentCommand(
            new DateTime(2025, 1, 14, 10, 30, 0),
            "Caldas",
            "Manizales",
            "Colision",
            new List<VehicleDto>
            {
                new("ABC123","123456789")
            },
             1,
            "Accidente menor"
        );
    }
}