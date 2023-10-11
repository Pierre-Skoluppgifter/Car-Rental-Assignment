using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Car : IVehicle
{
    public string RegNumber { get; init; }
    public VehicleBrands Brand { get; init; }
    public int Odometer { get; set; }
    public double CostPerKilometer { get; init; }
    public VehicleTypes VehicleType { get; init; }
    public int CostPerDay { get; init; }
    public VehicleStatuses VehicleStatus { get; set; }

    public Car(string regNumber, VehicleBrands brand, int odometer, double costPerKilometer, VehicleTypes vehicleType, int costPerDay, VehicleStatuses vehicleStatus)
    {
        RegNumber = regNumber;
        Brand = brand;
        Odometer = odometer;
        CostPerKilometer = costPerKilometer;
        VehicleType = vehicleType;
        CostPerDay = costPerDay;
        VehicleStatus = vehicleStatus;
    }
}
