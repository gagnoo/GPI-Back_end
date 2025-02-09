using MediatR;

namespace GPI.Application.Features.User.Commands.AuthUser;

public record AuthUserCommand(string Username, string Password) : IRequest<bool>;