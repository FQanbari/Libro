using Application.DTOs;
using Application.Interfaces;
using Domain.Entities.MemberAggregate;
using System.Numerics;

namespace Application.Services;

public class JwtService : IJWTService
{
    private readonly IMemberRepository _memberRepository;
    private readonly IJWTService _jwtService;

    public JwtService(IMemberRepository memberRepository)
    {
        this._memberRepository = memberRepository;
    } 



    public async Task<string> GenerateToken(string phone)
    {
        var user = await _memberRepository.GetByPhoneNumber(phone);
        if (user == null)
            throw new Exception("User is not exist.");

        var jwt = user.GenerateJwtToken();
        await _memberRepository.AddToken(jwt, user.Id.Value);
        return jwt;
    }

    public async Task<List<AuthorityDto>> GetTokens(int userId)
    {
        var member = await _memberRepository.GetById(userId);

        return member.InvalidTokens.Select(x => new AuthorityDto { Id = x.Id, CreateOn = x.CreateOn, Status = x.Status }).ToList();
    }

    public async Task InvalidateToken(string phone, string token)
    {
        var user = await _memberRepository.GetByPhoneNumber(phone);
        if (user == null)
            throw new Exception("User is not exist.");


        user.InvalidateJwtToken(token);
    }
}