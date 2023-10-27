using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Person : IPerson
{
    public int Id { get; set; }
    public int SSN { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Person(int id, int ssn, string firstName, string lastName)
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
