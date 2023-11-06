using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Classes;

public class InputValues
{
    public IVehicle Vehicle { get; set; } = new Vehicle();
    public IPerson Person { get; set; } = new Person();
    public int Distance { get; set; } = 0;

    public void ClearDistance() => Distance = 0;
    public void ClearVehicle() => Vehicle = new Vehicle();
    public void ClearPerson() => Person = new Person();
}

