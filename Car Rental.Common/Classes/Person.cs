using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Person : IPerson
{
    public int Id { get; set; }
    public string SSN { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public Person(int id, string ssn, string firstName, string lastName)
    {
        Id = id;
        SSN = ssn;
        FirstName = firstName;
        LastName = lastName;
    }
    public Person()
    {
    }
}
