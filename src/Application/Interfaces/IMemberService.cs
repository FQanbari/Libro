
using Application.DTOs;

namespace Application.Interfaces;

public interface IMemberService
{
    Task Add(string userName, string phoneNumber, string password);
    Task<UserDto> GetByPhone(string phone);
}
