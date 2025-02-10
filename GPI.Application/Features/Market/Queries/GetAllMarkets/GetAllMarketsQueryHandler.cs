using GPI.Persistence;
using GPI.Shared.Models.Market;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GPI.Application.Features.Market.Queries.GetAllMarkets;

public class GetAllMarketsQueryHandler(
    ApplicationDbContext context) : IRequestHandler<GetAllMarketsQuery, IEnumerable<MarketResponseModel>>
{
    public async Task<IEnumerable<MarketResponseModel>> Handle(GetAllMarketsQuery request, CancellationToken cancellationToken)
    {
        List<MarketResponseModel> markets = await context
            .Markets
            .AsNoTracking()
            .Select(i => new MarketResponseModel
            {
                Id = i.Id,
                Name = i.Name,
            })
            .ToListAsync(cancellationToken);
        return markets;
    }
}