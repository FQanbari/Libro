using Domain.Entities.MemberAggregate;
using Infrastructure.Data;
using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository;

public class MemberRepository : IMemberRepository
{
    private readonly ApplicationDbContext _dbContext;

    public MemberRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task Add(Member member)
    {
        throw new NotImplementedException();
    }

    public async Task Add(string userName, string phoneNumber, string password)
    {
        await _dbContext.MemberShips.AddAsync(new MemberShip { CreatOn = DateTime.Now, Expiration = DateTime.Now.AddMonths(6), Type = (byte)MembershipType.Regular, User = new User { Username = userName, PhoneNumber = phoneNumber, Password = password } });
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddOrUpdateOtp(int id, string inputOtp, DateTime expirationOtp)
    {
        var identity = await _dbContext.Identities.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        if (identity == null)
            await _dbContext.Identities.AddAsync(new Identity { Id = id, OtpCode = inputOtp, CreatOn = DateTime.Now, TokenStatus = (byte)TokenStatusType.NotSet, ExpirationOtp = expirationOtp });
        else
        {
            identity.OtpCode = inputOtp;
            identity.ExpirationOtp = expirationOtp;
            identity.TokenStatus = (byte)TokenStatusType.NotSet;
            _dbContext.Identities.Update(identity);
        }
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddToken(string token, int userId)
    {
        var identity = await _dbContext.Identities.Where(x => x.Id == userId).AsNoTracking().FirstOrDefaultAsync();
        identity.Token = token;
        identity.TokenStatus = (short)TokenStatusType.Valid;
        identity.ExpirationToken = DateTime.Now.AddMinutes(15);
        _dbContext.Identities.Update(identity);
        await _dbContext.SaveChangesAsync();
    }

    public Task<Member> GetById(int memberId)
    {
        throw new NotImplementedException();
    }

    public async Task<Member> GetByPhoneNumber(string phoneNumber)
    {
        var temp = await _dbContext.MemberShips.Include(x => x.User).Where(x => x.User.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        return await _dbContext.MemberShips
            .Include(x => x.User)
            .Where(x => x.User.PhoneNumber == phoneNumber)
            .Select(x => new Member(x.User.Name, x.User.Family, x.User.Username, x.User.PhoneNumber, 
            x.Expiration, (MembershipType)x.Type, _dbContext.Identities.Where(i => i.Id == x.Id).OrderByDescending(x => x.CreatOn).FirstOrDefault().OtpCode, _dbContext.Identities.Where(i => i.Id == x.Id).OrderByDescending(x => x.CreatOn).FirstOrDefault().ExpirationOtp, 5M ,x.Id,new List<int>(),new List<string>()
            //_dbContext.Identities.Where(i => i.Id == x.Id).OrderByDescending(x => x.CreatOn).FirstOrDefault().OtpCode,
            //_dbContext.Identities.Where(i => i.Id == x.Id).OrderByDescending(x => x.CreatOn).FirstOrDefault().Expiration,19M            
            //_dbContext.Payments.Where(x => x.Id == ) x.Payments.Sum(x => x.Amount * x.Count))
            )).FirstOrDefaultAsync();
    }

    public Task Update(Member member)
    {
        throw new NotImplementedException();
    }
}
