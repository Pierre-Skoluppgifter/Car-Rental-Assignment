using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Vehicle : IVehicle
{
    public int Id { get; set; }
    public string RegistrationNumber { get; set; }
    public VehicleBrand VehicleBrand { get; set; }
    public int Odometer { get; set; }
    public double CostPerKilometer { get; set; }
    public VehicleType VehicleType { get; set; }
    public int CostPerDay { get; set; }
    public VehicleStatuses VehicleStatus { get; set; }
}
