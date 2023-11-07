using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    public ICustomer Customer { get; set; }
    public IVehicle Vehicle { get; set; }
    public int Id { get; set; }
    public int KmRented { get; set; }
    public int? Distance { get; set; }
    public double? RentCost { get; set; }
    public DateTime DateRented { get; set; }
    public DateTime DateReturned { get; set; }
    public BookingStatus Status { get; set; }
}
