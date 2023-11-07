using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public int Id { get; set; }
    public IVehicle Vehicle { get; set; }
    public ICustomer Customer { get; set; }
    public int KmRented { get; set; }
    public int? Distance { get; set; } = null;
    public double? RentCost { get; set; } = null;
    public DateTime DateRented { get; set; }
    public DateTime DateReturned { get; set; }
    public BookingStatus Status { get; set; }

    public Booking(int id, ICustomer customer, IVehicle vehicle, int kmRent, int? distance, double? rentCost, DateTime dateRented, DateTime dateReturned, BookingStatus status)
    {
        Id = id;
        Customer = customer;
        Vehicle = vehicle;
        KmRented = kmRent;
        Distance = distance;
        RentCost = rentCost;
        DateRented = dateRented;
        DateReturned = dateReturned;
        Status = status;
    }
}
