namespace Application.Interfaces;

public interface ISMSService
{
    Task<bool> SendSms(string phoneNumber, string message);
}

public interface ISmsProvider
{
    Task<bool> SendSms(string phoneNumber, string message);
}