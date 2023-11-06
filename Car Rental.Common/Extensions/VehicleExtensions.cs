namespace Car_Rental.Common.Extensions;

public static class VehicleExtensions
{

    public static double Duration(this DateTime startDate, DateTime endDate, double costKm, int costDay, int distance)
    {
        double daysRented;
        if (endDate.ToShortDateString().Equals(startDate.ToShortDateString()))
        {
            daysRented = 1;
        }
        else
        {
            daysRented = (endDate - startDate).TotalDays;

        }
        var totalKmCost = distance * costKm;
        var totalRentCost = (daysRented * costDay) + totalKmCost;
        return Math.Round(totalRentCost);
    }
}
