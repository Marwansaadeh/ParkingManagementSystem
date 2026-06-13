using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingManagementSystem.Entities
{
    public class Airplane:Vehicle
    {
        public int NumberOfEngines { get; set; }
        public int MaxAltitude { get; set; }
    }
}
