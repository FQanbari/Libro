namespace Application.Interfaces;

public interface IOTPService
{
    Task<string> GenerateOtp(string phone);
    Task<bool> VerifyOtp(string phone, string inputOtp);
}