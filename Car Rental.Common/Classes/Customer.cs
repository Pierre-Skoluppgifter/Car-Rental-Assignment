using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Customer : ICustomer
{
    public int Id { get; set; }
    public string SSN { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public Customer(int id, string ssn, string firstName, string lastName)
    {
        Id = id;
        SSN = ssn;
        FirstName = firstName;
        LastName = lastName;
    }
    public Customer()
    {

    }
}
