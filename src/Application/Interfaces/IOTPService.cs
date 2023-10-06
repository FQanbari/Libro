namespace Application.Interfaces;

public interface IOTPService
{
    Task<string> Generate(string phone);
    Task<bool> Verify(string phone, string inputOtp);
}