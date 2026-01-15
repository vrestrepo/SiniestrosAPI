using Application.Common;
using Domain.Repositories;
using MediatR;

namespace Application.Accidents.Queries;

public class GetAccidentsQueryHandler : IRequestHandler<GetAccidentsQuery, PagedResult<AccidentDto>>
{
    private readonly IAccidentRepository _repository;

    public GetAccidentsQueryHandler(IAccidentRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<AccidentDto>> Handle(GetAccidentsQuery request, CancellationToken cancellationToken)
    {
        var (items, total) = await _repository.GetAsync(
            request.Department,
            request.From,
            request.To,
            request.Page,
            request.PageSize
        );

        var result = items.Select(a => new AccidentDto(
            a.Id,
            a.OccurredAt,
            a.Department,
            a.City,
            a.AccidentType,
            a.AccidentVehicles.Select(av =>
                new VehicleDto(
                    av.Vehicle.Id,
                    av.Vehicle.Plate,
                    av.Vehicle.OwnerIdentification)).ToList(),
            a.Victims,
            a.Description
        )).ToList();

        return new PagedResult<AccidentDto>(result, request.Page, request.PageSize, total);
    }
}
