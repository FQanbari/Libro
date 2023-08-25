using Infrastructure.Data.Models;
using Infrastructure.Data.Models.Base;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Principal;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Gener> Geners { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var entitiesAssembly = typeof(IEntity).Assembly;

        builder.RegisterAllEntities<IEntity>(entitiesAssembly);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
