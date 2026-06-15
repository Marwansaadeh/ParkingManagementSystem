using ParkingManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingManagementSystem.Factories
{
    public interface IVehicleInputHandler
    {
        Vehicle Create(VehicleType vehicleType);

    }
}
