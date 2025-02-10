using GPI.Domain.CompanyPriceModule;

namespace GPI.Domain.CompanyModule;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<CompanyPrice> CompanyPrices { get; set; }
}