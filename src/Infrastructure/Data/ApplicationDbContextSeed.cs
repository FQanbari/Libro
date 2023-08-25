using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data;

public static class ApplicationDbContextSeed
{
    public static async Task SeedAsync(ApplicationDbContext catalogContext,
        ILogger logger,
        //, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager
        int retry = 0)
    {
        var retryForAvailability = retry;
        try
        {
            if (catalogContext.Database.IsSqlServer())
            {
                catalogContext.Database.Migrate();
            }

            if (!await catalogContext.Cities.AnyAsync())
            {
                await catalogContext.Cities.AddRangeAsync(
                    GetPreconfiguredCities());

                await catalogContext.SaveChangesAsync();
            }

            if (!await catalogContext.Geners.AnyAsync())
            {
                await catalogContext.Geners.AddRangeAsync(
                    GetPreconfiguredGeners());

                await catalogContext.SaveChangesAsync();
            }

            if (!await catalogContext.Authors.AnyAsync())
            {
                await catalogContext.Authors.AddRangeAsync(
                    GetPreconfiguredAuthors());

                await catalogContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            if (retryForAvailability >= 10) throw;

            retryForAvailability++;

            logger.LogError(ex.Message);
            await SeedAsync(catalogContext, logger, retryForAvailability);
            throw;
        }
    }

    static IEnumerable<City> GetPreconfiguredCities()
    {
        return new List<City>
            {
                new City{ Id = 1, Name = "London"},
                new City{ Id = 2, Name = "Amsterdam"},
                new City{ Id = 3, Name = "Teharn"},
                new City{ Id = 4, Name = "New York"},
                new City{ Id = 5, Name = "Tokyo"},
                new City{ Id = 6, Name = "Istanbul"},
                new City{ Id = 7, Name = "Paris"},
                new City{ Id = 8, Name = "Buenos Aires"},
                new City{ Id = 9, Name = "Bangkok"},
                new City{ Id = 10, Name = "Prague"},
                new City{ Id = 11, Name = "Mexico City"},
                new City{ Id = 12, Name = "Hong kong"},
                new City{ Id = 13, Name = "Barcelona"},
                new City{ Id = 14, Name = "Dubai"},
                new City{ Id = 15, Name = "Madrid"},
            };
    }

    static IEnumerable<Gener> GetPreconfiguredGeners()
    {
        return new List<Gener>
        {
            new Gener{ Id = 1, Name = "Fiction"},
            new Gener{ Id = 2, Name = "Narrative"},
            new Gener{ Id = 3, Name = "Novel"},
            new Gener{ Id = 4, Name = "Mystery"},
            new Gener{ Id = 5, Name = "Science fiction"},
            new Gener{ Id = 6, Name = "Historical fiction"},
            new Gener{ Id = 7, Name = "Romance"},
            new Gener{ Id = 8, Name = "Thriller"},
        };
    }

    static IEnumerable<Author> GetPreconfiguredAuthors()
    {
        return new List<Author>
        {
            new Author{ Id = 1, Name = "Leo Tolstoy"},
            new Author{ Id = 2, Name = "J.K Rowling"},
            new Author{ Id = 3, Name = "Rebecca Zanetti"},
            new Author{ Id = 4, Name = "Stephanie Bond"},
            new Author{ Id = 5, Name = "Jeff Carson"},
            new Author{ Id = 6, Name = "Uncle Bob"},
        };
    }
}
