using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public int Id { get; set; }
    public IPerson Customer { get; set; }
    public IVehicle Vehicle { get; set; }
    public int KmRent { get; set; }
    public int? KmReturn { get; set; } = null;
    public double? RentCost { get; set; }
    public DateTime DateRented { get; set; }
    public DateTime DateReturned { get; set; }
    public VehicleStatus Status { get; set; }

    public Booking(int id, IPerson person, IVehicle vehicle, int kmRent, int? kmReturn, double? rentCost, DateTime dateRented, DateTime dateReturned, VehicleStatus status)
    {
        Id = id;
        Customer = person;
        Vehicle = vehicle;
        KmRent = kmRent;
        KmReturn = kmReturn;
        RentCost = rentCost;
        DateRented = dateRented;
        DateReturned = dateReturned;
        Status = status;
    }
}
