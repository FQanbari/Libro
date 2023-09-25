
using Application.DTOs;

namespace Application.Interfaces;

public interface IMemberService
{
    Task<UserDto> GetByPhone(string phone);
}
