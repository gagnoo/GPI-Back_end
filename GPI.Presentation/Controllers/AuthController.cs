using GPI.Application.Features.User.Commands.AuthUser;
using GPI.Infrastructure.Interfaces.Services;
using GPI.Presentation.Models;
using GPI.Presentation.Models.ApiResponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GPI.Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController(
    ISender sender,
    ITokenService tokenService) : ControllerBase
{
    [HttpPost("authorize")]
    public async Task<ActionResult<BaseApiResponse<string>>> Auth(
        [FromBody] AuthRequestModel request,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            return new BadRequestApiServiceResponse<string>(string.Empty, "Username or password is missing.");

        bool authResponse = await sender.Send(new AuthUserCommand(request.Username, request.Password), cancellationToken);
        if (!authResponse)
            return new UnauthorizedApiServiceResponse<string>(string.Empty, "Username or password is incorrect.");

        string token = tokenService.GenerateToken(request.Username);
        return new SuccessApiServiceResponse<string>(token);
    }
}