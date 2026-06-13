using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingManagementSystem.Entities
{
    public class Boat:Vehicle
    {
        public double Length { get; set; } 
        public string HullType { get; set; } = null!;
    }
}
