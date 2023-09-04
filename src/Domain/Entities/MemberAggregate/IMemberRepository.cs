namespace Domain.Entities.MemberAggregate;

public interface IMemberRepository
{
    Task<Member> GetById(int memberId);
    Task<Member> GetByPhoneNumber(string phoneNumber);
    Task Add(Member member);
    Task Update(Member member);
}
