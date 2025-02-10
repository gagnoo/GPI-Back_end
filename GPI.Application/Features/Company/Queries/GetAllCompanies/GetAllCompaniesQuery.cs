using GPI.Shared.Models.Company;
using MediatR;

namespace GPI.Application.Features.Company.Queries.GetAllCompanies;

public record GetAllCompaniesQuery() : IRequest<List<CompanyResponseModel>>;