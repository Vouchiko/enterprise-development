using DispatcherService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DispatcherService.Domain;

/// <summary>
/// Контекст базы данных для работы с сущностями DispatcherService.
/// </summary>
public class DispatcherServiceContext(DbContextOptions<DispatcherServiceContext> options) : DbContext(options)
{
    /// <summary>
    /// Таблица водителей.
    /// </summary>
    public DbSet<Driver> Drivers { get; set; }

    /// <summary>
    /// Таблица расписаний.
    /// </summary>
    public DbSet<Schedule> Schedules { get; set; }

    /// <summary>
    /// Таблица транспорта.
    /// </summary>
    public DbSet<Transport> Transports { get; set; }

    /// <summary>
    /// Настройка схемы базы данных с использованием Fluent API.
    /// </summary>
    /// <param name="modelBuilder">Объект для настройки схемы базы данных.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Связь Schedule с Driver 
        modelBuilder.Entity<Schedule>()
            .HasOne(s => s.Driver)
            .WithMany(d => d.Schedules)
            .HasForeignKey(s => s.DriverId)
            .OnDelete(DeleteBehavior.Cascade); 

        // Связь Schedule с Transport
        modelBuilder.Entity<Schedule>()
            .HasOne(s => s.Transport)
            .WithMany(t => t.Schedules)
            .HasForeignKey(s => s.TransportId)
            .OnDelete(DeleteBehavior.Restrict); 

        // Связь Driver с Schedule 
        modelBuilder.Entity<Driver>()
            .HasMany(d => d.Schedules)
            .WithOne(s => s.Driver)
            .HasForeignKey(s => s.DriverId)
            .OnDelete(DeleteBehavior.Cascade); 

        // Связь Transport с Schedule
        modelBuilder.Entity<Transport>()
            .HasMany(t => t.Schedules)
            .WithOne(s => s.Transport)
            .HasForeignKey(s => s.TransportId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}
