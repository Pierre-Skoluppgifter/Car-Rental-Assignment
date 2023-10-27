using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Data.Interfaces;

public interface IData
{

    List<T> Get<T>(Func<T, bool>? expression);
    //T? Single<T>(Expression<Func<T, bool>>? expression);
    public void Add<T>(T item);
    //IBooking RentVehicle(IBooking booking);

    int NextVehicleId { get; }
    int NextPersonId { get; }
    int NextBookingId { get; }

    //IBooking ReturnVehicle(int vehicleId);
    // Default Interface Methods
    //public string[] VehicleStatusNames => Retunera enum konstanterna
    //public string[] VehicleTypeNames => Retunera enum konstanterna
    //public VehicleTypes GetVehicleType(string name) => //Retunera en enum konstants värde med hjälp av konstantens namn
}
