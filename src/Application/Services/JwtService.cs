using Application.Interfaces;
using Domain.Entities.MemberAggregate;
using System.Numerics;

namespace Application.Services;

public class JwtService : IJWTService
{
    private readonly IMemberRepository _memberRepository;

    public JwtService(IMemberRepository memberRepository)
    {
        this._memberRepository = memberRepository;
    }
    public async Task<string> GenerateToken(string phone)
    {
        var user = await _memberRepository.GetByPhoneNumber(phone);
        if (user == null)
            throw new Exception("User is not exist.");

        
        return user.GenerateJwtToken();
    }

    public async Task InvalidateToken(string phone, string token)
    {
        var user = await _memberRepository.GetByPhoneNumber(phone);
        if (user == null)
            throw new Exception("User is not exist.");


        user.InvalidateJwtToken(token);
    }
}