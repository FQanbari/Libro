namespace WebAPI.Model;

public class RegisterRequestModel
{
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
public class LoginRequestModel
{
    public string PhoneNumber { get; set; }
    public string Otp { get; set; }
}

public class PremiumMemberRequestModel
{
    public int Id { get; set; }
}