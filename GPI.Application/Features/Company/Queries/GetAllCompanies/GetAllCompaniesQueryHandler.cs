using GPI.Persistence;
using GPI.Shared.Models.Company;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GPI.Application.Features.Company.Queries.GetAllCompanies;

public class GetAllCompaniesQueryHandler(
    ApplicationDbContext context) : IRequestHandler<GetAllCompaniesQuery, List<CompanyResponseModel>>
{
    public async Task<List<CompanyResponseModel>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        List<CompanyResponseModel> companies = await context
            .Companies
            .AsNoTracking()
            .Select(i => new CompanyResponseModel
            {
                Id = i.Id,
                Name = i.Name,
            })
            .ToListAsync(cancellationToken);
        return companies;
    }
}