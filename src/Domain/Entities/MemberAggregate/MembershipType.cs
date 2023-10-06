namespace Domain.Entities.MemberAggregate;

public enum MembershipType : byte
{
    Regular = 1,
    Premium
}
public enum TokenStatusType: byte
{
    NotSet,
    Valid,
    Expired
}