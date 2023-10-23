using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Classes;

public class Motorcycle : Vehicle
{
    public Motorcycle(int id, string regNumber, VehicleBrand brand, int odometer, double costPerKilometer, VehicleType vehicleType, int costPerDay, VehicleStatuses vehicleStatus)
    {
        Id = id;
        RegistrationNumber = regNumber;
        VehicleBrand = brand;
        Odometer = odometer;
        CostPerKilometer = costPerKilometer;
        VehicleType = vehicleType;
        CostPerDay = costPerDay;
        VehicleStatus = vehicleStatus;
    }
}
