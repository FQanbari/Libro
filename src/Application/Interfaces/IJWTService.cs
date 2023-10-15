using Application.DTOs;

namespace Application.Interfaces;

public interface IJWTService
{
    Task<string> GenerateToken(string phone);
    Task<List<AuthorityDto>> GetTokens(int userId);
    Task InvalidateToken(string phone, string token);
}
