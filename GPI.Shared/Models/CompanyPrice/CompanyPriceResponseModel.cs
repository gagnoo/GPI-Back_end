namespace GPI.Shared.Models.CompanyPrice;

public class CompanyPriceResponseModel
{
    public int Id { get; set; }

    public string CompanyName { get; set; } = null!;
    public int CompanyId { get; set; }

    public string MarketName { get; set; } = null!;
    public int MarketId { get; set; }

    public decimal Price { get; set; }
}