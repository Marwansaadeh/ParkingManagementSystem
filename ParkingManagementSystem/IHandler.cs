using ParkingManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ParkingManagementSystem
{
    public interface IHandler
    {
        IEnumerable<VehicleTypeCount> GetParkedVehiclesWithTotal();
        List<string> GetVehiclesTypes();
        bool ParkVehicle(Vehicle vehicle);
        bool RemoveVehicle(string registrationNumber);
        void AddTtoalParks(int numberOfParks);
        void SeedParks(int numberOfParks);
        Vehicle GetVehicle(string registrationNumber);
        IEnumerable<Vehicle> GetParkedVehicles();
        Vehicle FindVehicle(Func<Vehicle, bool> predicate);

    }
}
