using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Extensions;

public static class TokenExtension
{
    public static int Id(this ClaimsPrincipal principal)
    {
        return int.Parse(principal.Claims.FirstOrDefault(x => x.Type == Consts.Claims.UserId).Value);
    }
}

public static class Utilise
{
    public static string Hash(this string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}