using MediatR;

namespace GPI.Application.Features.CompanyPrice.Commands.UpdateCompanyPrice;

public record UpdateCompanyPriceCommand(
    int Id,
    int MarketId,
    int CompanyId,
    decimal Price) : IRequest<bool>;