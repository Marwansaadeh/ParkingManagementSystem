using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingManagementSystem.Entities
{
    public abstract class Vehicle
    {
        public string RegistrationNumber { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int NumberOfWheels { get; set; }
        public double Weight { get; set; }             
        public int MaxSpeed { get; set; }
        public virtual string ToString()
        {
            return $"Registration: {RegistrationNumber}, Color: {Color}, Wheels: {NumberOfWheels}, Weight: {Weight}, MaxSpeed: {MaxSpeed}";
        }
    }
}
