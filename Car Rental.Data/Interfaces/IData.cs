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

    public string? Error { get; set; }
    List<T> Get<T>(Func<T, bool>? expression);
    T? Single<T>(Expression<Func<T, bool>>? expression);
    public void Add<T>(T item);


    IBooking RentVehicle(int vehicleId, int customerId)
    {
        var vehicle = Single<IVehicle>(v => v.Id == vehicleId);
        var customer = Single<IPerson>(p => p.Id == customerId);
        
        Booking booking = new(NextBookingId, customer, vehicle, vehicle.Odometer, null, null, DateTime.Now, DateTime.Now, VehicleStatus.Booked);
        Add<IBooking>(booking);
        vehicle.Status = VehicleStatus.Booked;
        return booking;
    }
    void ReturnVehicle(int vehicleId)
    {
        var dateReturn = DateTime.Now;
        var returnBooking = Single<IBooking>(b => b.Vehicle.Id == vehicleId);
        var vehicle = Single<IVehicle>(v => v.Id == vehicleId);
        returnBooking.RentCost = VehicleExtensions.Duration(returnBooking.DateRented, returnBooking.DateReturned, returnBooking.Vehicle.CostKm, returnBooking.Vehicle.CostDay, (int)returnBooking.KmReturn);
        vehicle.Odometer += (int)returnBooking.KmReturn;
        returnBooking.KmReturn = vehicle.Odometer;
        returnBooking.Status = VehicleStatus.Available;
        vehicle.Status = VehicleStatus.Available;
    }
    public int VehicleTypes(string name) => (int)Enum.Parse(typeof(VehicleTypes),name);
}
