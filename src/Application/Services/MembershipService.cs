using Application.Interfaces;
using Domain.Entities.MemberAggregate;
using Domain.Exceptions;

namespace Application.Services;

public class MembershipService : IMembershipService
{
    private readonly IMemberRepository _memberRepository;

    public MembershipService(IMemberRepository memberRepository)
    {
        this._memberRepository = memberRepository;
    }
    public Task GenerateAndSendOtp(int memberId, ISMSService smsService)
    {
        throw new NotImplementedException();
    }

    public Task InvalidateToken(int memberId, IJWTService jwtService)
    {
        throw new NotImplementedException();
    }

    public async Task PurchasePremiumMembership(int memberId)
    {
        // Retrieve the member from the repository.
        var member = await _memberRepository.GetById(memberId);

        if (member == null)
        {
            throw new MemberNotFoundException(memberId);
        }

        member.PurchasePremiumMembership();


        _memberRepository.Update(member);

        //_unitOfWork.Commit();
    }

    public Task VerifyOtpAndGenerateToken(int memberId, string inputOtp, IJWTService jwtService)
    {
        throw new NotImplementedException();
    }
}
