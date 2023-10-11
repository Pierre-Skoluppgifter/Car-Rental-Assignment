using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public int SSN { get; set; }
    public IVehicle Vehicle { get; set; }
    public string RegNumber { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int KmRented { get; set; }
    public int KmReturned { get; set; }
    public DateTime DateRented { get; set; }
    public DateTime? DateReturned { get; set; }
    public double? RentCost { get; set; }
    public VehicleStatuses VehicleStatus { get; set; }

    public Booking(int ssn, IVehicle vehicle, string regNumber, string firstName, string lastName, int kmRented, int kmReturned, DateTime dateRented, DateTime? dateReturned, VehicleStatuses vehicleStatuses)
    {
        SSN = ssn;
        Vehicle = vehicle;
        RegNumber = regNumber;
        FirstName = firstName;
        LastName = lastName;
        KmRented = kmRented;
        KmReturned = kmReturned;
        DateRented = dateRented;
        DateReturned = dateReturned;
        RentCost = CalculateRentCost();
        VehicleStatus = vehicleStatuses;
    }
    private double? CalculateRentCost()
    {
        if (Vehicle.VehicleStatus is VehicleStatuses.Closed && DateReturned is not null)
        {
            var kmCost = KmCost(KmRented, KmReturned, Vehicle.CostPerKilometer);
            double daysRented = DaysRented(DateRented, (DateTime)DateReturned);
            var totalRentalCost = kmCost + (daysRented * Vehicle.CostPerDay);
            return totalRentalCost;
        }
        return null;

    }
    private double KmCost(double kmRented, double kmReturned, double costPerKm)
    {
        var totalKmDriven = kmReturned - kmRented;
        var totalKmCost = totalKmDriven * costPerKm;
        return totalKmCost;
    }
    private double DaysRented(DateTime dateRented, DateTime dateReturned)
    {
        var x = dateReturned - dateRented;
        return Math.Round(x.TotalDays, 0);
    }
}
