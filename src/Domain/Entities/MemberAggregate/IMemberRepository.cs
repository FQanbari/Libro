namespace Domain.Entities.MemberAggregate;

public interface IMemberRepository
{
    Task<Member> GetById(int memberId);
    Task<Member> GetByPhoneNumber(string phoneNumber);
    Task Add(Member member);
    Task Update(Member member);
    Task Add(string userName, string phoneNumber, string password);
    Task AddOrUpdateOtp(int id, string inputOtp, DateTime expirationOtp);
    Task AddToken(string token, int userId);
}
