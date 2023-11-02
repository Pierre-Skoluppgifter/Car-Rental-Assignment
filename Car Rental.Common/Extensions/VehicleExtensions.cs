using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Extensions;

public static class VehicleExtensions
{
    
    public static double Duration(this DateTime startDate, DateTime endDate,IVehicle? vehicle, int? distance)
    {
        var duration = (endDate - startDate).TotalDays;
        var totalRentCost = RentCost(duration, distance, (double)vehicle.CostKm, (int)vehicle.CostDay);
        return totalRentCost;
    }
    public static int RentCost(double totalDays, int? distance, double costKm, int costDay)
    {
        double? kmCost = distance * costKm;
        double? rentCost = (totalDays * costDay) + kmCost;
        //if(rentCost == null) rentCost = 0;
        return (int)rentCost;
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
