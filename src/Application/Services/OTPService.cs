using Application.Interfaces;
using Domain.Entities.MemberAggregate;

namespace Application.Services;

public class OTPService : IOTPService
{
    private readonly IMemberRepository _memberRepository;

    public OTPService(IMemberRepository memberRepository)
    {
        this._memberRepository = memberRepository;
    }
    public async Task<string> Generate(string phone)
    {
        var user = await _memberRepository.GetByPhoneNumber(phone);
        if (user == null)
            throw new Exception("User is not exist.");

        user.GenerateOtp();
        await _memberRepository.AddOrUpdateOtp(user.Id.Value, user.OtpCode, user.OtpExpirationTime);
        return user.OtpCode;
    }   

    public async Task<bool> Verify(string phone, string inputOtp)
    {
        var user = await _memberRepository.GetByPhoneNumber(phone);
        if (user == null)
            throw new Exception("User is not exist.");        

        return user.VerifyOtp(inputOtp);
    }
}
