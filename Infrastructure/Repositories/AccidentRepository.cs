using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AccidentRepository : IAccidentRepository
{
    private readonly AppDbContext _context;

    public AccidentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Accident accident)
    {
        _context.Accidents.Add(accident);
        await _context.SaveChangesAsync();
    }

    public async Task<(IReadOnlyList<Accident> Items, int Total)> GetAsync(
        string? department,
        DateTime? from,
        DateTime? to,
        int page,
        int pageSize)
    {
        var query = _context.Accidents
            .Include(a => a.AccidentVehicles)
            .ThenInclude(av => av.Vehicle)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(department))
            query = query.Where(x => x.Department == department);

        if (from.HasValue)
            query = query.Where(x => x.OccurredAt >= from.Value);

        if (to.HasValue)
            query = query.Where(x => x.OccurredAt <= to.Value);

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x => x.OccurredAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, total);
    }
}
