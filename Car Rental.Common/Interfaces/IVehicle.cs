using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IVehicle
{
    public int Id { get; set; }
    public string? RegNumber { get; set; }
    public VehicleBrands Brands { get; set; }
    public int Odometer { get; set; }
    public double CostKm { get; set; }
    public VehicleTypes Type { get; set; }
    public int CostDay { get; set; }
    public VehicleStatus Status { get; set; }
}
