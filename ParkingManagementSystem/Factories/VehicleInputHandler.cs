using ParkingManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingManagementSystem.Factories
{
    public class VehicleInputHandler: IVehicleInputHandler
    {
        public Vehicle Create(VehicleType vehicleType)
        {
            return vehicleType switch
            {
                VehicleType.Car => new Car(),
                VehicleType.Motorcycle => new Motorcycle(),
                VehicleType.Bus => new Bus(),
                VehicleType.Boat => new Boat(),
                VehicleType.Airplane => new Airplane(),
                _ => throw new ArgumentException("Invalid vehicle type")
            };
        }
    }
}
