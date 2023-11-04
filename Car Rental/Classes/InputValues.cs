using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Classes;

public class InputValues
{
    public IVehicle Vehicle { get; private set; } = new Vehicle();
    public IPerson Person { get; set; } = new Person();    
}

