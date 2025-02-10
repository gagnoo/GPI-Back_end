using GPI.Application.Features.Company.Queries.GetAllCompanies;
using GPI.Presentation.Models.ApiResponses;
using GPI.Shared.Models.Company;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GPI.Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CompanyController(
    ISender sender) : ControllerBase
{
    [HttpGet("list")]
    public async Task<ActionResult<BaseApiResponse<List<CompanyResponseModel>>>> GetCompanies(
        CancellationToken cancellationToken = default)
    {
        List<CompanyResponseModel> companies = await sender.Send(new GetAllCompaniesQuery(), cancellationToken);
        return new SuccessApiServiceResponse<List<CompanyResponseModel>>(companies);
    }
}