namespace Application.Interfaces;

public interface IJWTService
{
    Task<string> GenerateToken(string phone);
    Task InvalidateToken(string phone, string token);
}
