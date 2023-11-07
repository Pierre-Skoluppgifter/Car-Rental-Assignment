using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class InputValues
{
    public IVehicle Vehicle { get; set; } = new Vehicle();
    public ICustomer Customer { get; set; } = new Customer();

    public void ClearVehicle() => Vehicle = new Vehicle();
    public void ClearPerson() => Customer = new Customer();
}

