using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IVehicle
{
    public string RegNumber { get; init; }
    public VehicleBrands Brand { get; init; }
    public int Odometer { get; set; }
    public double CostPerKilometer { get; init; }
    public VehicleTypes VehicleType { get; init; }
    public int CostPerDay { get; init; }
    public VehicleStatuses VehicleStatus { get; set; }
}
