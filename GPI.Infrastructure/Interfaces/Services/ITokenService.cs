namespace GPI.Infrastructure.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(string username);
}