namespace Domain.Exceptions;

public class MemberNotFoundException : Exception
{
    public MemberNotFoundException(int memberId)
        :base()
    {
        
    }
}
