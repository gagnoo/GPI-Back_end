using System.Reflection;
using GPI.Domain.CompanyModule;
using GPI.Domain.CompanyPriceModule;
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

    public static void SeedData(ApplicationDbContext context)
    {
        #region Company

        Company company1 = new()
        {
            Id = 1,
            Name = "Company 1",
        };
        Company company2 = new()
        {
            Id = 2,
            Name = "Company 2",
        };
        Company company3 = new()
        {
            Id = 3,
            Name = "Company 3",
        };
        Company company4 = new()
        {
            Id = 4,
            Name = "Company 4",
        };
        Company company5 = new()
        {
            Id = 5,
            Name = "Company 5",
        };

        context.Companies.AddRange(company1, company2, company3, company4, company5);

        #endregion

        #region Market

        Market market1 = new()
        {
            Id = 1,
            Name = "Market 1",
        };

        Market market2 = new()
        {
            Id = 2,
            Name = "Market 2",
        };

        Market market3 = new()
        {
            Id = 3,
            Name = "Market 3",
        };

        context.Markets.AddRange(market1, market2, market3);

        #endregion

        #region Market Price

        CompanyPrice companyPrice1 = new()
        {
            Id = 1,
            Company = company1,
            MarketId = 1,
            Price = 2,
            LastUpdated = DateTime.UtcNow
        };

        CompanyPrice companyPrice2 = new()
        {
            Id = 2,
            Company = company2,
            MarketId = 2,
            LastUpdated = DateTime.UtcNow,
            Price = 3
        };

        CompanyPrice companyPrice3 = new()
        {
            Id = 3,
            Company = company3,
            MarketId = 3,
            LastUpdated = DateTime.UtcNow,
            Price = 4
        };

        CompanyPrice companyPrice4 = new()
        {
            Id = 4,
            Company = company3,
            MarketId = 2,
            LastUpdated = DateTime.UtcNow,
            Price = 6
        };

        context.CompanyPrices.AddRange(companyPrice1, companyPrice2, companyPrice3, companyPrice4);

        #endregion

        context.SaveChanges();
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Market> Markets { get; set; }
    public DbSet<CompanyPrice> CompanyPrices { get; set; }
}