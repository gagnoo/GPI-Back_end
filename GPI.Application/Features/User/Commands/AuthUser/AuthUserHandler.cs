using MediatR;

namespace GPI.Application.Features.User.Commands.AuthUser;

public class AuthUserHandler : IRequestHandler<AuthUserCommand, bool>
{
    public async Task<bool> Handle(AuthUserCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(request.Username.Equals("admin")) && await Task.FromResult(request.Password.Equals("admin"));
    }
}