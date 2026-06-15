using ParkingManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace ParkingManagementSystem
{
    public class Handler : IHandler
    {
        private IGarage<Vehicle> _garage;
        public Handler(IGarage<Vehicle> garage)
        {
            _garage = garage;
        }
        public int ParkedVehicles()
        {
            return _garage.Count;
        }
        public int ParkCapacity()
        {
            return _garage.Capacity;
        }
        public IEnumerable<Vehicle> SearchVehicles(Func<Vehicle, bool> predicate)
        {
            return _garage.Where(predicate);
        }

        public IEnumerable<Vehicle> GetParkedVehicles()
        {
            return _garage;
        }

        public IEnumerable<VehicleTypeCount> GetTotalParkedType()
        {
            return _garage
                   .GroupBy(v => v.VehicleType)
                   .Select(g => new VehicleTypeCount(
                       g.Key,
                       g.Count()
                   ));
        }

        public Vehicle? GetVehicle(string registrationNumber)
        {
            return _garage.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }

        public StringBuilder GetVehiclesTypes()
        {
            var sb = new StringBuilder();

            foreach (var item in _garage.Select(v => v.GetType().Name))
            {
                sb.AppendLine($"{item}");
            }

            return sb;
        }

        public bool ParkVehicle(Vehicle vehicle)
        {
            if (_garage.Count < _garage.Capacity)
            {
                return _garage.Park(vehicle);
            }

            return false;
        }

        public bool RemoveVehicle(string registrationNumber)
        {
            return _garage.Remove(registrationNumber);
        }

        public void SeedVehicles(IEnumerable<Vehicle> vehicles)
        {
            foreach (var v in vehicles)
            {
                _garage.Park(v);
            }
        }

        public bool CreateGarage(int capacity)
        {
            if (capacity <= 0)
                return false;
            _garage = new Garage<Vehicle>(capacity);

            return true;
        }
    }
}
