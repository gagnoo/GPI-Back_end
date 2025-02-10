using GPI.Shared.Models.CompanyPrice;
using MediatR;

namespace GPI.Application.Features.CompanyPrice.Queries.GetAllCompanyPrice;

public record GetAllCompanyPriceQuery : IRequest<IEnumerable<CompanyPriceResponseModel>>;