using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class InputValues
{
    public IVehicle Vehicle { get; set; } = new Vehicle();
    public IPerson Person { get; set; } = new Person();

    public void ClearVehicle() => Vehicle = new Vehicle();
    public void ClearPerson() => Person = new Person();
}

