namespace Car_Rental.Common.Extensions;

public static class VehicleExtensions
{

    public static double Duration(this DateTime startDate, DateTime endDate)
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
        return daysRented;
    }
}
