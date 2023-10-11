namespace Car_Rental.Common.Interfaces;

public interface IPerson
{
    public int SocialSecurityNumber { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
}
