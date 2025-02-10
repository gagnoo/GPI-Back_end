using GPI.Application.Features.CompanyPrice.Commands.UpdateCompanyPrice;
using GPI.Application.Features.CompanyPrice.Queries.GetAllCompanyPrice;
using GPI.Presentation.Hubs;
using GPI.Presentation.Models.ApiResponses;
using GPI.Presentation.Models.CompanyPrice;
using GPI.Shared.Models.CompanyPrice;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace GPI.Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CompanyPriceController(
    ISender sender,
    IHubContext<SignalRClient> hubContext) : ControllerBase
{
    [HttpGet("list")]
    public async Task<ActionResult<BaseApiResponse<IEnumerable<CompanyPriceResponseModel>>>> GetCompaniesPrice(
        CancellationToken cancellationToken = default)
    {
        IEnumerable<CompanyPriceResponseModel> companyPrices = await sender.Send(new GetAllCompanyPriceQuery(), cancellationToken);
        return new SuccessApiServiceResponse<IEnumerable<CompanyPriceResponseModel>>(companyPrices);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateCompanyPrice(
        [FromBody] UpdateCompanyPriceRequest request,
        CancellationToken cancellationToken = default)
    { 
        bool updateResult = await sender.Send(new UpdateCompanyPriceCommand(
            request.Id,
            request.MarketId,
            request.CompanyId,
            request.Price), cancellationToken);
        if (!updateResult)
        {
            return new BadRequestResult();
        }

        IEnumerable<CompanyPriceResponseModel> companyPrices = await sender.Send(new GetAllCompanyPriceQuery(), cancellationToken);
        await hubContext.Clients.All.SendAsync("UpdateCompanyPrice", companyPrices, cancellationToken: cancellationToken);
        return Ok();
    }
}