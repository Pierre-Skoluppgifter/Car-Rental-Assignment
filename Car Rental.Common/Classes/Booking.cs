using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public IPerson Customer { get; set; }
    public IVehicle Vehicle { get; set; }
    public int Id { get; set; }
    public int? KmRent { get; set; }
    public int? KmReturn { get; set; }
    public double? RentCost { get; set; }
    public DateTime DateRented { get; set; }
    public DateTime DateReturned { get; set; }
    public VehicleStatus Status { get; set; }

    public Booking(int id, IPerson person, IVehicle vehicle, int kmRented, int? kmReturned, double? rentCost, DateTime dateRented, DateTime dateReturned, VehicleStatus status)
    {
        Id = id;
        Customer = person;
        Vehicle = vehicle;
        Vehicle.Odometer = kmRented;
        RentCost = rentCost;
        DateRented = dateRented;
        Status = status;
        DateReturned = dateReturned;
        KmReturn = kmReturned;
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
