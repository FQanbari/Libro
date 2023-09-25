using System.Security.Claims;

namespace Infrastructure.Extensions;

public static class TokenExtension
{
    public static int Id(this ClaimsPrincipal principal)
    {
        return int.Parse(principal.Claims.FirstOrDefault(x => x.Type == Consts.Claims.UserId).Value);
    }
}