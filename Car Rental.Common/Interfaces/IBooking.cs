using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
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
}
