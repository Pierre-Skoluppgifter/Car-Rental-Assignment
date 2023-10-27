using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    public IPerson Person { get; set; }
    public IVehicle Vehicle { get; set; }
    public int Id { get; set; }
    public int KmReturned { get; set; }
    public DateTime DateRented { get; set; }
    public DateTime DateReturned { get; set; }
    public double CostKm { get; set; }
    public int CostDay { get; set; }
    public VehicleStatus status { get; set; }
}
