using Application.Interfaces;

namespace Application.Services;

public class KavenegarSmsService : ISMSService
{
    public async Task<bool> SendSms(string phoneNumber, string message)
    {
        // Implement Kavenegar SMS sending logic.
        return true;
    }
}
public class SignalCompanySmsService : ISMSService
{
    public async Task<bool> SendSms(string phoneNumber, string message)
    {
        // Implement Signal Company SMS sending logic.
        return true;
    }
}
