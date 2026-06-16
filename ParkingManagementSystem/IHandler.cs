using ParkingManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ParkingManagementSystem
{
    public interface IHandler
    {
        int ParkCapacity();
        int ParkedVehicles();
        IEnumerable<VehicleTypeCount> GetTotalParkedType();
        StringBuilder GetVehiclesTypes();
        bool ParkVehicle(Vehicle vehicle);
        bool UnParkVehicle(string registrationNumber);
        void SeedVehicles(IEnumerable<Vehicle> vehicles);
        Vehicle? GetVehicle(string registrationNumber);
        IEnumerable<Vehicle> GetParkedVehicles();
        IEnumerable<Vehicle> SearchVehicles(Func<Vehicle, bool> predicate);
        bool CreateGarage(int capacity);
    }
}
