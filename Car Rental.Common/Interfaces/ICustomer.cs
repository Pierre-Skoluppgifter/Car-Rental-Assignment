﻿namespace Car_Rental.Common.Interfaces;

public interface ICustomer
{
    public int Id { get; set; }
    public string SSN { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
