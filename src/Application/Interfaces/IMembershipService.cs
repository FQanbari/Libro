namespace Application.Interfaces;

public interface IMembershipService
{
    Task Premium(int memberId);
    //Task GenerateAndSendOtp(int memberId, ISMSService smsService);
    //Task VerifyOtpAndGenerateToken(int memberId, string inputOtp, IJWTService jwtService);
    //Task InvalidateToken(int memberId, IJWTService jwtService);
}
