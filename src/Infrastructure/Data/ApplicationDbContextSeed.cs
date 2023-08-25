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
    public static async Task SeedAsync(ApplicationDbContext context,
        ILogger logger,
        //, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager
        int retry = 0)
    {
        var retryForAvailability = retry;
        try
        {
            if (context.Database.IsSqlServer())
            {
                context.Database.Migrate();
            }
            
            if (!await context.Cities.AnyAsync())
            {
                await context.Cities.AddRangeAsync(
                    GetPreconfiguredCities());

                await context.SaveChangesAsync();
            }

            if (!await context.Geners.AnyAsync())
            {
                await context.Geners.AddRangeAsync(
                    GetPreconfiguredGeners());

                await context.SaveChangesAsync();
            }

            if (!await context.Authors.AnyAsync())
            {
                await context.Authors.AddRangeAsync(
                    GetPreconfiguredAuthors());

                await context.SaveChangesAsync();
            }

        }
        catch (Exception ex)
        {
            if (retryForAvailability >= 10) throw;

            retryForAvailability++;

            logger.LogError(ex.Message);
            await SeedAsync(context, logger, retryForAvailability);
            throw;
        }
    }

    static IEnumerable<City> GetPreconfiguredCities()
    {
        return new List<City>
            {
                new City{ Name = "London"},
                new City{ Name = "Amsterdam"},
                new City{ Name = "Teharn"},
                new City{ Name = "New York"},
                new City{ Name = "Tokyo"},
                new City{ Name = "Istanbul"},
                new City{ Name = "Paris"},
                new City{ Name = "Buenos Aires"},
                new City{ Name = "Bangkok"},
                new City{ Name = "Prague"},
                new City{ Name = "Mexico City"},
                new City{ Name = "Hong kong"},
                new City{ Name = "Barcelona"},
                new City{ Name = "Dubai"},
                new City{ Name = "Madrid"},
            };
    }

    static IEnumerable<Gener> GetPreconfiguredGeners()
    {
        return new List<Gener>
        {
            new Gener{ Name = "Fiction"},
            new Gener{ Name = "Narrative"},
            new Gener{ Name = "Novel"},
            new Gener{ Name = "Mystery"},
            new Gener{ Name = "Science fiction"},
            new Gener{ Name = "Historical fiction"},
            new Gener{ Name = "Romance"},
            new Gener{ Name = "Thriller"},
        };
    }

    static IEnumerable<Author> GetPreconfiguredAuthors()
    {
        return new List<Author>
        {
            new Author{ Name = "Leo Tolstoy"},
            new Author{ Name = "J.K Rowling"},
            new Author{ Name = "Rebecca Zanetti"},
            new Author{ Name = "Stephanie Bond"},
            new Author{ Name = "Jeff Carson"},
            new Author{ Name = "Uncle Bob"},
        };
    }
}
