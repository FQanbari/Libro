namespace Application.Interfaces;

public interface IMemeberService
{
    Task PurchasePremiumMembership(int memberId);
    Task GenerateAndSendOtp(int memberId, ISMSService smsService);
    Task VerifyOtpAndGenerateToken(int memberId, string inputOtp, IJWTService jwtService);
    Task InvalidateToken(int memberId, IJWTService jwtService);
}
