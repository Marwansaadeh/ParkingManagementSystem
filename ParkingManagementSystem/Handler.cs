using ParkingManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingManagementSystem
{
    public class Handler : IHandler
    {
        //private readonly IGarage<Vehicle> _garage;
        public void AddTtoalParks(int numberOfParks)
        {
            throw new NotImplementedException();
        }

        public Vehicle FindVehicle(Func<Vehicle, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> GetParkedVehicles()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleTypeCount> GetParkedVehiclesWithTotal()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicle(string registrationNumber)
        {
            throw new NotImplementedException();
        }

        public List<string> GetVehiclesTypes()
        {
            throw new NotImplementedException();
        }

        public bool ParkVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public bool RemoveVehicle(string registrationNumber)
        {
            throw new NotImplementedException();
        }

        public void SeedParks(int numberOfParks)
        {
            throw new NotImplementedException();
        }
    }
}
