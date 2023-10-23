using Car_Rental.Common.Classes;

namespace Car_Rental.Common.Extensions;

public static class VehicleExtensions
{
    public static int Duration(this DateTime startDate, DateTime endDate)
    {
        int value = default;
        return value;
    }
    //public static void Add<T>(this List<T> Vehicle, T vehicle);
    //public static double? CalculateRentCost(Booking booking)
    //{
    //    if (booking.VehicleStatus == Enums.VehicleStatuses.Closed && booking.DateReturned is not null)
    //    {
    //        var kmCost = KmCost(booking.KmRented, booking.KmReturned, booking.CostKm);
    //        double daysRented = DaysRented(booking.DateRented, booking.DateReturned);
    //        var totalRentalCost = kmCost + (daysRented * booking.Vehicle.CostPerDay);
    //        return totalRentalCost;
    //    }
    //    return null;

    //}

    //private static int DaysRented(DateTime dateRented, DateTime? dateReturned)
    //{
    //    var x = dateReturned - dateRented;
    //    return Math.Round(TimeSpan., 0);
    //}

    //private static double KmCost(double kmRented, double kmReturned, double costPerKm)
    //{
    //    var totalKmDriven = kmReturned - kmRented;
    //    var totalKmCost = totalKmDriven * costPerKm;
    //    return totalKmCost;
    //}
}
