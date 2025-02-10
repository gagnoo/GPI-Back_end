using GPI.Persistence;
using GPI.Shared.Models.CompanyPrice;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GPI.Application.Features.CompanyPrice.Queries.GetAllCompanyPrice;

public class GetAllCompanyPriceQueryHandler(
    ApplicationDbContext context) : IRequestHandler<GetAllCompanyPriceQuery, IEnumerable<CompanyPriceResponseModel>>
{
    public async Task<IEnumerable<CompanyPriceResponseModel>> Handle(GetAllCompanyPriceQuery request, CancellationToken cancellationToken)
    {
        List<CompanyPriceResponseModel> companyPrices = await context
            .CompanyPrices
            .Join(context.Companies,
                i => i.CompanyId,
                i => i.Id,
                (companyPrice, company) => new { companyPrice, company })
            .Join(context.Markets,
                i => i.companyPrice.MarketId,
                i => i.Id,
                (prices, market) => new
                {
                    CompanyPrice = prices.companyPrice,
                    Company = prices.company,
                    Market = market
                })
            .Select(i => new CompanyPriceResponseModel
            {
                Id = i.CompanyPrice.Id,
                CompanyName = i.Company.Name,
                CompanyId = i.Company.Id,
                MarketName = i.Market.Name,
                MarketId = i.Market.Id,
                Price = i.CompanyPrice.Price,
            })
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return companyPrices;
    }
}