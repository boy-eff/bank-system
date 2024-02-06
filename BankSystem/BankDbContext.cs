using BankSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem;

public class BankDbContext : DbContext
{
    public BankDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<CitizenshipEntity> Citizenship { get; set; }
    public DbSet<CityEntity> Cities { get; set; }
    public DbSet<DisabilityEntity> Disabilities { get; set; }
    public DbSet<MaritalStatusEntity> MaritalStatuses { get; set; }
    public DbSet<SexEntity> Sexes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserEntity>().HasIndex(x => new { x.PassportSeries, x.PassportNumber }).IsUnique();
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.IdentificationNumber).IsUnique();
        
    }
}