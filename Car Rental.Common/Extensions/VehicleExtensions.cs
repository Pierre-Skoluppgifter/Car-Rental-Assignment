using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Extensions;

public static class VehicleExtensions
{
    
    public static double Duration(this DateTime startDate, DateTime endDate,IBooking booking, IVehicle vehicle, int? distance)
    {
        double duration = (endDate - startDate).TotalDays;
        double totalRentCost = RentCost(duration, booking, vehicle, distance);
        return totalRentCost;
    }
    public static double RentCost(double totalDays, IBooking booking, IVehicle vehicle, int? distance)
    {
        var kmCost = (distance * vehicle.CostKm);
        var rentCost = kmCost + (totalDays * vehicle.CostDay);
        return (double)rentCost;
    }

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
