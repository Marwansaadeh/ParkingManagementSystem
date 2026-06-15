using ParkingManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingManagementSystem.Utilites
{
    public class Seeder
    {

        public readonly MenuItem[] MenuItems =
    [
        new(1, "Create Garage"),
    new(2, "Show Capacity"),
    new(3, "List Vehicles"),
    new(4, "List Vehicle Types"),
    new(5, "Add Vehicle"),
    new(6, "Find Vehicle"),
    new(7, "Search Vehicles"),
    new(8, "Remove Vehicle"),
    new(0, "Exit")
    ];

        public readonly Vehicle[] vehicles = [

            new Airplane
{
    VehicleType = VehicleType.Airplane,
    RegistrationNumber = "SE-ABC",
    Color = "White",
    NumberOfWheels = 12,
    Weight = 45000,
    MaxSpeed = 900,

    NumberOfEngines = 2,
    MaxAltitude = 12000
},
           new Boat
{
               VehicleType=VehicleType.Boat,
    RegistrationNumber = "BOAT-001",
    Color = "Blue",
    NumberOfWheels = 0,
    Weight = 2500,
    MaxSpeed = 60,

    Length = 8.5,
    HullType = "Monohull"
},
            new Bus
{
                VehicleType=VehicleType.Bus,
    RegistrationNumber = "BUS-001",
    Color = "Yellow",
    NumberOfWheels = 6,
    Weight = 12000,
    MaxSpeed = 100,

    NumberOfSeats = 50,
    IsDoubleDecker = false
},
    new Car
{
        VehicleType=VehicleType.Car,
    RegistrationNumber = "CAR-001",
    Color = "Black",
    NumberOfWheels = 4,
    Weight = 1500,
    MaxSpeed = 220,

    FuelType = FuelType.Diesel,
    NumberOfDoors = 4
},
         new Car
{
    VehicleType=VehicleType.Car,
    RegistrationNumber = "CAR-002",
    Color = "White",
    NumberOfWheels = 4,
    Weight = 1800,
    MaxSpeed = 200,

    FuelType = FuelType.Electric,
    NumberOfDoors = 2
},
           new Motorcycle
{
               VehicleType= VehicleType.Motorcycle,
    RegistrationNumber = "MC-002",
    Color = "Black",
    NumberOfWheels = 3,
    Weight = 350,
    MaxSpeed = 140,

    CylinderVolume = 750,
    HasSidecar = true
}

            ];
    }

}