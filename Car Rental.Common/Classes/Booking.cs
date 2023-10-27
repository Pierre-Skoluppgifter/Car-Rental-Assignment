using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public IPerson Person { get; set; }
    public IVehicle Vehicle { get; set; }
    public int Id { get; set; }
    public int KmReturned { get; set; }
    public DateTime DateRented { get; set; }
    public DateTime DateReturned { get; set; }
    public double CostKm { get; set; }
    public int CostDay { get; set; }
    public VehicleStatus status { get; set; }

    public Booking(int id, IPerson person, IVehicle vehicle, int kmReturned, DateTime dateRented, DateTime dateReturned, double costKm, int costDay, VehicleStatus vehicleStatuses)
    {
        Id = id;
        Person = person;
        Vehicle = vehicle;
        KmReturned = kmReturned;
        DateRented = dateRented;
        DateReturned = dateReturned;
        CostKm = costKm;
        CostDay = costDay;
        status = vehicleStatuses;
    }

    public Booking()
    {
    }

    //public double? RentCost()
    //{
    //    if (Vehicle.Status is VehicleStatus.Closed && DateReturned is not )
    //    {
    //        var kmCost = KmCost(Vehicle.Odometer, KmReturned, Vehicle.CostKm);
    //        double daysRented = DaysRented(DateRented, (DateTime)DateReturned);
    //        var totalRentalCost = kmCost + (daysRented * Vehicle.CostDay);
    //        return totalRentalCost;
    //    }
    //    return null;

    //}

    //private double KmCost(double kmRented, double kmReturned, double costPerKm)
    //{
    //    var totalKmDriven = kmReturned - kmRented;
    //    var totalKmCost = totalKmDriven * costPerKm;
    //    return totalKmCost;
    //}

    //private double DaysRented(DateTime dateRented, DateTime dateReturned)
    //{
    //    var x = dateReturned - dateRented;
    //    return Math.Round(x.TotalDays, 0);
    //}
}
