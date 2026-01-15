using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Accident> Accidents => Set<Accident>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<AccidentVehicle> AccidentVehicles => Set<AccidentVehicle>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccidentVehicle>()
            .HasKey(x => new { x.AccidentId, x.VehicleId });

        modelBuilder.Entity<AccidentVehicle>()
            .HasOne(x => x.Accident)
            .WithMany(x => x.AccidentVehicles)
            .HasForeignKey(x => x.AccidentId);

        modelBuilder.Entity<AccidentVehicle>()
            .HasOne(x => x.Vehicle)
            .WithMany()
            .HasForeignKey(x => x.VehicleId);
    }
}
