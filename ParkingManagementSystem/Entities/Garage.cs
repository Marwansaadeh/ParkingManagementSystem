using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace ParkingManagementSystem.Entities
{
    public class Garage<T> : IGarage<T>
        where T : Vehicle
    {
        private readonly int _capacity;
        private readonly T?[] _vehicles;
        public int Capacity => _capacity;
        public int Count { get; private set; }

        public Garage(int capacity)
        {
            _vehicles = new T[capacity];
            _capacity = capacity;
        }
       
        public bool Park(T vehicle)
        {
            if (Count >= Capacity)
                return false;

            foreach (var v in _vehicles)
            {
                if (v?.RegistrationNumber == vehicle.RegistrationNumber)
                    return false;
            }

            for (int i = 0; i < _vehicles.Length; i++)
            {
                if (_vehicles[i] == null)
                {
                    _vehicles[i] = vehicle;
                    Count++;
                    return true;
                }
            }

            return false;
        }

        public bool UnPark(string registrationNumber)
        {
            if (string.IsNullOrEmpty(registrationNumber))
                throw new ArgumentException("Registration number cannot be null or empty.", nameof(registrationNumber));

            for (int i = 0; i < _vehicles.Length; i++)
            {
                if (_vehicles[i] != null &&
                    _vehicles[i]?.RegistrationNumber == registrationNumber)
                {
                    _vehicles[i] = null;
                    Count--;
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in _vehicles)
            {
                if (vehicle != null)
                {
                    yield return vehicle;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
