using Application.Common;
using MediatR;

namespace Application.Accidents.Queries;

public record GetAccidentsQuery(
    string? Department,
    DateTime? From,
    DateTime? To,
    int Page,
    int PageSize
) : IRequest<PagedResult<AccidentDto>>;
