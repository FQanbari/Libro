using Infrastructure.Data.Models;
using Infrastructure.Data.Models.Base;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
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
    public DbSet<MemberShip> MemberShips { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Identity> Identities { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var entitiesAssembly = typeof(IEntity).Assembly;

        builder.RegisterAllEntities<IEntity>(entitiesAssembly);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

//public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
//{
//    public ApplicationDbContext CreateDbContext(string[] args)
//    {
//        IConfigurationRoot configuration = new ConfigurationBuilder()
//           .SetBasePath(Directory.GetCurrentDirectory())
//           .AddJsonFile("appsettings.json")
//           .Build();

//        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
//        var connectionString = configuration.GetConnectionString("DefaultConnection");
//        builder.UseSqlServer(connectionString);


//        return new ApplicationDbContext(builder.Options);
//    }
//}