using GPI.Domain.CompanyModule;

namespace GPI.Domain.CompanyPriceModule;

public class CompanyPrice
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;
    public int MarketId { get; set; }
    public Market Market { get; set; } = null!;
    public decimal Price { get; set; }
    public DateTime LastUpdated { get; set; }
}