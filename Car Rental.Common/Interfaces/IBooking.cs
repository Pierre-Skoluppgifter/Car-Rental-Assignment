using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
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
}
