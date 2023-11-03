using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Extensions;

public static class VehicleExtensions
{
    
    public static double Duration(this DateTime startDate, DateTime endDate,double costKm, int costDay, int distance)
    {
        var daysRented = (endDate - startDate).TotalDays;
        if (daysRented == 0)
        {
            daysRented = 1;
        }
        var totalKmCost = distance * costKm;
        var totalRentCost = (daysRented * costDay) + totalKmCost;
        return totalRentCost;
    }
}
