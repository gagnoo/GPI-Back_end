namespace GPI.Domain.CompanyPriceModule;

public class CompanyPrice
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int MarketId { get; set; }
    public decimal Price { get; set; }
    public DateTime LastUpdated { get; set; }
}