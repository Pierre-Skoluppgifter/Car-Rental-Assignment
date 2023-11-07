using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Extensions;
using Car_Rental.Common.Interfaces;
using System.Linq.Expressions;

namespace Car_Rental.Data.Interfaces;

public interface IData
{
    int NextVehicleId { get; }
    int NextPersonId { get; }
    int NextBookingId { get; }
    public string[] VehicleStatusNames => Enum.GetNames(typeof(VehicleBrands));
    public string[] VehicleTypeNames => Enum.GetNames(typeof(VehicleTypes));

    List<T> Get<T>(Func<T, bool>? expression);
    T? Single<T>(Expression<Func<T, bool>>? expression);
    public void Add<T>(T item);

    IBooking RentVehicle(IVehicle vehicle, int customerId)
    {
        var customer = Single<ICustomer>(p => p.Id == customerId);
        var booking = new Booking(NextBookingId, customer, vehicle, vehicle.Odometer, 0, null, DateTime.Now, DateTime.Now, BookingStatus.Open);
        Add<IBooking>(booking);
        vehicle.Status = VehicleStatus.Booked;
        return booking;
    }
    IBooking ReturnVehicle(IVehicle vehicle, int distance)
    {
        var booking = Single<IBooking>(b => b.Vehicle.Id == vehicle.Id && b.Status == BookingStatus.Open);
        booking.Distance = distance;
        var dateReturn = DateTime.Now;
        var rentedDays = VehicleExtensions.Duration(booking.DateRented, dateReturn);
        var totalKmCost = booking.Distance * booking.Vehicle.CostKm;
        var totalRentCost = (rentedDays * booking.Vehicle.CostDay) + totalKmCost;
        booking.RentCost = totalRentCost;

        booking.Vehicle.Odometer += (int)booking.Distance;
        booking.Distance = booking.Vehicle.Odometer;
        booking.Vehicle.Status = VehicleStatus.Available;
        booking.Status = BookingStatus.Closed;
        return booking;
    }
    public int VehicleTypes(string name) => (int)Enum.Parse(typeof(VehicleTypes),name);
}
