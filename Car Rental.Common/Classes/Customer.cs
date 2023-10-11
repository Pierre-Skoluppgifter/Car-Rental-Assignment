using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes
{
    public class Customer : IPerson
    {
        public int SocialSecurityNumber { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public Customer(int socialSecurityNumber, string firstName, string lastName)
        {
            SocialSecurityNumber = socialSecurityNumber;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
