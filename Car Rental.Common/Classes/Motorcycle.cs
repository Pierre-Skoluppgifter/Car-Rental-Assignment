using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Classes;

public class Motorcycle : Vehicle
{
    public Motorcycle(int id, string regNumber, VehicleBrands brands, int odometer, double costKm, VehicleTypes vehicleType, int costDay, VehicleStatus vehicleStatus)
    {
        Id = id;
        RegNumber = regNumber;
        Brands = brands;
        Odometer = odometer;
        CostKm = costKm;
        Type = vehicleType;
        CostDay = costDay;
        Status = vehicleStatus;
    }
}
