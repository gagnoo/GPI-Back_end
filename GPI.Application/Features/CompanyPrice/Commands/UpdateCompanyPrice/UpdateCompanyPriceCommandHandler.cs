using GPI.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GPI.Application.Features.CompanyPrice.Commands.UpdateCompanyPrice;

public class UpdateCompanyPriceCommandHandler(
    ApplicationDbContext context) : IRequestHandler<UpdateCompanyPriceCommand, bool>
{
    public async Task<bool> Handle(UpdateCompanyPriceCommand request, CancellationToken cancellationToken)
    {
        Domain.CompanyPriceModule.CompanyPrice? companyPrice = await context
            .CompanyPrices
            .FirstOrDefaultAsync(i => i.Id == request.Id
                                      && i.MarketId == request.MarketId
                                      && i.CompanyId == request.CompanyId, cancellationToken: cancellationToken);
        if (companyPrice == null)
            return false;

        companyPrice.Price = request.Price;
        context.CompanyPrices.Update(companyPrice);
        return await context.SaveChangesAsync(cancellationToken) > 0;
    }
}