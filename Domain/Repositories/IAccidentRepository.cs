using Domain.Entities;

namespace Domain.Repositories;

public interface IAccidentRepository
{
    Task AddAsync(Accident accident);
    Task<(IReadOnlyList<Accident> Items, int Total)> GetAsync(
        string? department,
        DateTime? from,
        DateTime? to,
        int page,
        int pageSize);
}
