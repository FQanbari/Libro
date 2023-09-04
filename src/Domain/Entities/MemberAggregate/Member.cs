using Domain.Entities.BookAggregate;

namespace Domain.Entities.MemberAggregate;

public class Member
{
    public int? Id { get; set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string Username { get; private set; }
    public string PhoneNumber { get; private set; }
    public DateTime? ExpireDate { get; private set; }
    public MembershipType MembershipType { get; private set; }
    public string OtpCode { get; private set; }
    public DateTime OtpExpirationTime { get; private set; }
    public void GenerateOtp()
    {
        OtpExpirationTime = DateTime.Now;
        OtpCode = string.Empty;
    }
    public bool VerifyOtp(string inputOtp)
    {
        if(inputOtp == OtpCode && OtpExpirationTime > DateTime.Now)
            return true;

        return false;
    }

    public void GenerateJwtToken()
    {

    }
    public void InvalidateJwtToken(string token)
    {

    }
    public void PurchasePremiumMembership()
    {

    }
    public List<Book> Reservations => new List<Book>(); 
    public List<Payment> TotalPayments => new List<Payment>(); // last tow month
    public void MakeReservation(int bookId)
    {
        // TODO: Allows a member to make a book reservation.
    }
    public void PurchaseMembership()
    {
        // TODO: Handles the purchase of a premium membership.
    }
    public void CalculateDiscount()
    {
        // TODO: Calculates the applicable discount for the member based on the payment and reading history.
    }
}
public class Book
{

}
public class Payment
{

}