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

    public async Task Premium(int memberId)
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
}
