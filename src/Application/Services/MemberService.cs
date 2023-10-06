using Application.DTOs;
using Application.Interfaces;
using Domain.Entities.MemberAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;

    public MemberService(IMemberRepository memberRepository)
    {
        this._memberRepository = memberRepository;
    }
    public async Task Add(string userName, string phoneNumber, string password)
    {
        await _memberRepository.Add(userName, phoneNumber, password);
    }

    public Task<UserDto> GetByPhone(string phone)
    {
        throw new NotImplementedException();
    }
}
