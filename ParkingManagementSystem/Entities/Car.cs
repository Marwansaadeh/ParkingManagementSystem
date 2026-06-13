using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingManagementSystem.Entities
{
    public class Car:Vehicle
    {
        public FuelType FuelType { get; set; } 
        public int NumberOfDoors { get; set; }
    }
}
