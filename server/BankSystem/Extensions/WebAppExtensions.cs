using BankSystem.Entities;

namespace BankSystem.Extensions;

public static class WebAppExtensions
{
    public static async Task RecreateAndSeedDatabaseAsync(this WebApplication webApplication)
    {
        using var scope = webApplication.Services.CreateScope();
        await using var context = scope.ServiceProvider.GetService<BankDbContext>();

        if (context is null)
        {
            throw new Exception("DbContext is not registered");
        }
        
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        context.SeedData();
    }

    private static void SeedData(this BankDbContext dbContext)
    {
        // Ensure the database is created
        dbContext.Database.EnsureCreated();

        // Seed data for each entity
        SeedCitizenshipEntities(dbContext);
        SeedCityEntities(dbContext);
        SeedDisabilityEntities(dbContext);
        SeedMaritalStatusEntities(dbContext);
        SeedSexEntities(dbContext);
    }

    private static void SeedCitizenshipEntities(BankDbContext dbContext)
    {
        if (!dbContext.Set<CitizenshipEntity>().Any())
        {
            var citizenshipEntities = new CitizenshipEntity[]
            {
                new() { Id = 1, Name = "Belarus" },
                new() { Id = 2, Name = "Russia" }
                // Add more entities as needed
            };

            foreach (var entity in citizenshipEntities)
            {
                dbContext.Set<CitizenshipEntity>().Add(entity);
            }

            dbContext.SaveChanges();
        }
    }

    private static void SeedCityEntities(BankDbContext dbContext)
    {
        if (!dbContext.Set<CityEntity>().Any())
        {
            var cityEntities = new CityEntity[]
            {
                new() { Id = 1, Name = "Minsk" },
                new() { Id = 2, Name = "Hrodna" }
                // Add more entities as needed
            };

            foreach (var entity in cityEntities)
            {
                dbContext.Set<CityEntity>().Add(entity);
            }

            dbContext.SaveChanges();
        }
    }

    private static void SeedDisabilityEntities(BankDbContext dbContext)
    {
        if (!dbContext.Set<DisabilityEntity>().Any())
        {
            var disabilityEntities = new DisabilityEntity[]
            {
                new() { Id = 1, Name = "No Disability" },
                new() { Id = 2, Name = "Autism" }
                // Add more entities as needed
            };

            foreach (var entity in disabilityEntities)
            {
                dbContext.Set<DisabilityEntity>().Add(entity);
            }

            dbContext.SaveChanges();
        }
    }

    private static void SeedMaritalStatusEntities(BankDbContext dbContext)
    {
        if (!dbContext.Set<MaritalStatusEntity>().Any())
        {
            var maritalStatusEntities = new MaritalStatusEntity[]
            {
                new() { Id = 1, Name = "Single" },
                new() { Id = 2, Name = "Married" }
                // Add more entities as needed
            };

            foreach (var entity in maritalStatusEntities)
            {
                dbContext.Set<MaritalStatusEntity>().Add(entity);
            }

            dbContext.SaveChanges();
        }
    }

    private static void SeedSexEntities(BankDbContext dbContext)
    {
        if (!dbContext.Set<SexEntity>().Any())
        {
            var sexEntities = new SexEntity[]
            {
                new() { Id = 1, Name = "Male" },
                new() { Id = 2, Name = "Female" },
                // Add more entities as needed
            };

            foreach (var entity in sexEntities)
            {
                dbContext.Set<SexEntity>().Add(entity);
            }

            dbContext.SaveChanges();
        }
    }
}