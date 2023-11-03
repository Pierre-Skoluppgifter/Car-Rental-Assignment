using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    public IPerson Customer { get; set; }
    public IVehicle Vehicle { get; set; }
    public int Id { get; set; }
    public int KmRent { get; set; }
    public int? KmReturn { get; set; }
    public double? RentCost { get; set; }
    public DateTime DateRented { get; set; }
    public DateTime DateReturned { get; set; }
    public VehicleStatus Status { get; set; }
}
