using GPI.Shared.Models.Market;
using MediatR;

namespace GPI.Application.Features.Market.Queries.GetAllMarkets;

public record GetAllMarketsQuery() : IRequest<IEnumerable<MarketResponseModel>>;