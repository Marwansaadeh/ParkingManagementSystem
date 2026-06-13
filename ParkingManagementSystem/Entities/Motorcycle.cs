using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingManagementSystem.Entities
{
    public class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; set; } 
        public bool HasSidecar { get; set; }

    }
}
