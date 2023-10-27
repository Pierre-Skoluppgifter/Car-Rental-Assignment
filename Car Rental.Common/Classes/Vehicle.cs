using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Vehicle : IVehicle
{
    public int Id { get; set; }
    public string RegNumber { get; set; } = string.Empty;
    public VehicleBrands Brands { get; set; }
    public int Odometer { get; set; }
    public double CostKm { get; set; }
    public VehicleTypes Type { get; set; }
    public int CostDay { get; set; }
    public VehicleStatus Status { get; set; }
}
