﻿using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Car : Vehicle
{
    public Car(int id, string regNumber, VehicleBrands brands, int odometer, double costKm, VehicleTypes vehicleType, int costDay, VehicleStatus status)
    {
        Id = id;
        RegNumber = regNumber;
        Brands = brands;
        Odometer = odometer;
        CostKm = costKm;
        Type = vehicleType;
        CostDay = costDay;
        Status = status;
    }
}
