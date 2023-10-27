namespace Car_Rental.Common.Extensions;

public static class VehicleExtensions
{
    public static double Duration(this DateTime startDate, DateTime endDate)
    {
        var duration = (endDate - startDate).TotalDays;
        //RentCost(duration);
        return duration;
    }
    //public static double RentCost(double days)
    //{
    //    var kmCost = (Vehicle.Odometer, KmReturned, Vehicle.CostKm);
    //    double daysRented = DaysRented(DateRented, (DateTime)DateReturned);
    //    var totalRentalCost = kmCost + (daysRented * Vehicle.CostDay);
    //    return totalRentalCost;

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
