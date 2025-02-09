using System.Reflection;
using GPI.Domain.CompanyModule;
using GPI.Domain.CompanyPriceModule;
using GPI.Domain.MarketModule;
using Microsoft.EntityFrameworkCore;

namespace GPI.Persistence;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Market> Markets { get; set; }
    public DbSet<CompanyPrice> CompanyPrices { get; set; }
}