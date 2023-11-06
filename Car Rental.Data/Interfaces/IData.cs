using Car_Rental.Common.Enums;
using System.Linq.Expressions;

namespace Car_Rental.Data.Interfaces;

public interface IData
{
    List<T> Get<T>(Func<T, bool>? expression);
    T? Single<T>(Expression<Func<T, bool>>? expression);
    public void Add<T>(T item);
    //IBooking RentVehicle(IBooking booking);

    int NextVehicleId { get; }
    int NextPersonId { get; }
    int NextBookingId { get; }

    //IBooking RentVehicle(int vehicleId, int customerId); Använder inte metoden verkar fungera ändå?
    //IBooking ReturnVehicle(int vehicleId); Använder inte metoden verkar fungera ändå?
    public string[] VehicleStatusNames => Enum.GetNames(typeof(VehicleBrands));
    public string[] VehicleTypeNames => Enum.GetNames(typeof(VehicleTypes));
}
