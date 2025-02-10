namespace GPI.Presentation.Models.CompanyPrice;

public class UpdateCompanyPriceRequest
{
    public int Id { get; set; }
    public int MarketId { get; set; }
    public int CompanyId { get; set; }
    public decimal Price { get; set; }
}