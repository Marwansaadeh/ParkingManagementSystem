using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingManagementSystem.Entities
{
    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }
        public bool IsDoubleDecker { get; set; }

    }
}
