using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public int Id { get; set; }
    public int SSN { get; set; }
    public string RegistrationNumber { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int KmRented { get; set; }
    public int KmReturned { get; set; }
    public DateTime DateRented { get; set; }
    public DateTime? DateReturned { get; set; }
    public double CostKm { get; set; }
    public int CostDay { get; set; }
    public VehicleStatuses status { get; set; }

    public Booking(int id, int ssn, string registrationNumber, string firstName, string lastName, int kmRented, int kmReturned, DateTime dateRented, DateTime? dateReturned, double costKm, int costDay, VehicleStatuses vehicleStatuses)
    {

        Id = id;
        SSN = ssn;
        RegistrationNumber = registrationNumber;
        FirstName = firstName;
        LastName = lastName;
        KmRented = kmRented;
        KmReturned = kmReturned;
        DateRented = dateRented;
        DateReturned = dateReturned;
        CostKm = costKm;
        CostDay = costDay;
        status = vehicleStatuses;
    }

    //public double? CalculateRentCost()
    //{
    //    if (Vehicle.VehicleStatus is VehicleStatuses.Closed && DateReturned is not null)
    //    {
    //        var kmCost = KmCost(KmRented, KmReturned, Vehicle.CostPerKilometer);
    //        double daysRented = DaysRented(DateRented, (DateTime)DateReturned);
    //        var totalRentalCost = kmCost + (daysRented * Vehicle.CostPerDay);
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
