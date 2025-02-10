using System.Diagnostics;
using GPI.Application.Features.CompanyPrice.Queries.GetAllCompanyPrice;
using GPI.Presentation.Hubs;
using GPI.Shared.Models.CompanyPrice;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;

namespace GPI.Presentation.BackgroundServices;

public class UpdateCompanyPricesBackgroundService(
    ISender sender,
    IHubContext<SignalRClient> hubContext) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                Debug.WriteLine("UpdateCompanyPricesBackgroundService is running.");
                IEnumerable<CompanyPriceResponseModel> companyPrices = await sender.Send(new GetAllCompanyPriceQuery(), stoppingToken);
                await hubContext.Clients.All.SendAsync("UpdateCompanyPrice", companyPrices, cancellationToken: stoppingToken);
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }
    }
}