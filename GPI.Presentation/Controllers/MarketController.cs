using GPI.Application.Features.Market.Queries.GetAllMarkets;
using GPI.Presentation.Models.ApiResponses;
using GPI.Shared.Models.Market;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GPI.Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MarketController(
    ISender sender) : ControllerBase
{
    [HttpGet("list")]
    public async Task<ActionResult<BaseApiResponse<IEnumerable<MarketResponseModel>>>> GetMarkets(
        CancellationToken cancellationToken = default)
    {
        IEnumerable<MarketResponseModel> markets = await sender.Send(new GetAllMarketsQuery(), cancellationToken);
        return new SuccessApiServiceResponse<IEnumerable<MarketResponseModel>>(markets);
    }
}