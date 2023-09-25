using Domain.Entities.BookReservationAggregate;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Domain.Entities.MemberAggregate;

public class Member
{
    public Member(string name, string family, string username, string phoneNumber, DateTime expiryDate, 
        MembershipType membershipType, string optCode,DateTime otpExpirationTime, decimal payments, int? id = null, 
        List<int> reservations = null, List<string> invalidToken = null)
    {
        Id = id;
        Name = name;
        Family = family;
        Username = username;
        PhoneNumber = phoneNumber;
        MembershipExpiryDate = expiryDate;
        MembershipType = membershipType;
        OtpCode = optCode;
        OtpExpirationTime = otpExpirationTime;
        _reservations = reservations ?? new List<int>();
        _invalidTokens = invalidToken ?? new List<string>();
        TotalPayments = payments;
    }
    public int? Id { get; set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string Username { get; private set; }
    public string PhoneNumber { get; private set; }
    public DateTime? MembershipExpiryDate { get; private set; }
    public MembershipType MembershipType { get; private set; }
    public string OtpCode { get; private set; }
    public DateTime OtpExpirationTime { get; private set; }
    private List<int> _reservations { get; set; }
    public IReadOnlyList<int> Reservations => _reservations;
    public decimal TotalPayments { get; private set; }
    private List<string> _invalidTokens { get; set; } // Store invalid JWT tokens.
    private IReadOnlyList<string> InvalidTokens => _invalidTokens;

    public void GenerateOtp()
    {
        // Implement logic to generate a new OTP code and set its expiration time.
        Random random = new Random();
        int otp = random.Next(1000, 9999); // Generate a random 4-digit OTP.
        OtpCode = otp.ToString();
        OtpExpirationTime = DateTime.Now.AddMinutes(10); // OTP expires in 10 minutes.
    }

    public bool VerifyOtp(string inputOtp)
    {
        // Implement logic to verify if the provided OTP matches the stored OTP and is not expired.
        return OtpCode == inputOtp && DateTime.Now <= OtpExpirationTime;
    }

    public string GenerateJwtToken()
    {
        var securityKey = Encoding.UTF8.GetBytes("*L!b3r0O@{2023}*"); // longer than 16 character
        var sign = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256Signature);
        var claims = _getClaims();
        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = "Libro org.",
            Audience = "Libro org.",
            IssuedAt = DateTime.Now,
            NotBefore = DateTime.Now,
            Expires = DateTime.Now.AddHours(1),
            SigningCredentials = sign,
            Subject = new ClaimsIdentity(claims)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(descriptor);
        return tokenHandler.WriteToken(securityToken);
    }

    private IEnumerable<Claim> _getClaims()
    {
        return new List<Claim>
        {
            new Claim(ClaimTypes.Name, Username),
            new Claim(ClaimTypes.NameIdentifier, Encoding.UTF8.GetBytes(PhoneNumber).ToString())
        };
    }

    public void InvalidateJwtToken(string token)
    {
        // Implement logic to mark a JWT token as invalid.
        _invalidTokens.Add(token);
    }

    public void PurchasePremiumMembership()
    {
        // Implement logic for members to purchase a premium membership.
        if (MembershipType == MembershipType.Regular)
        {
            // Set MembershipType to Premium and update the MembershipExpiryDate accordingly.
            MembershipType = MembershipType.Premium;
            MembershipExpiryDate = DateTime.Now.AddMonths(1); // Extend membership for one month.
        }
        else
        {
            throw new Exception("Premium membership is already active.");
        }
    }
    
    public void MakeReservation(int bookId)
    {
        
        if (MembershipType == MembershipType.Regular && Reservations.Count >= 3)
        {
            throw new Exception("Regular members can only reserve up to 3 books.");
        }

        _reservations.Add(bookId);
    }
    public void PurchaseMembership()
    {
        MembershipType = MembershipType.Premium;
        MembershipExpiryDate = DateTime.Now.AddMonths(1); // Set premium membership expiration (e.g., 12 months from now).

    }
    public decimal CalculateDiscount()
    {
        decimal discount = 0;

        if (TotalPayments >= 300)
        {
            discount = 10; // 10% discount if total payments in the last two months exceed 300.
        }

        return discount;
    }
}