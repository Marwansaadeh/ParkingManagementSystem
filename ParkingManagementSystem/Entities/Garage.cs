using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace ParkingManagementSystem.Entities
{
    public class Garage<T>: IEnumerable<T>
    {
        private T[] _vehicles;
        public Garage(int capacity)
        {
            _vehicles = new T[capacity];
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
      
        public bool Park(T vehicle)
        {
            for (int i = 0; i < _vehicles.Length; i++)
            {
                if (_vehicles[i] == null)
                {
                    _vehicles[i] = vehicle;
                    return true;
                }
            }
            return false;
         }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
