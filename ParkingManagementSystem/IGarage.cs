using ParkingManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingManagementSystem
{
    public interface IGarage<T>  where T : Vehicle 
    {
        bool Park(T vehicle);
        bool Remove(string registrationNumber);

        int Capacity { get; }
        int Count { get; }

    }
}
