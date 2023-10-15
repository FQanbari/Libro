using Application.Interfaces;
using Polly;

namespace Application.Services;

public class SMSService : ISMSService
{
    private readonly ISmsProvider _smsProvider;

    public SMSService(ISmsProvider smsProvider)
    {
        _smsProvider = smsProvider;
    }

    public async Task<bool> SendSms(string phoneNumber, string message)
    {
        return await _smsProvider.SendSms(phoneNumber, message);
    }
}