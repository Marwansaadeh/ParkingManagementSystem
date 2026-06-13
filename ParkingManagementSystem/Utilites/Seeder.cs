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
        new(2, "List All Vehicles"),
        new(3, "Show Vehicle Statistics"),
        new(4, "Park Vehicle"),
        new(5, "Remove Vehicle"),
        new(6, "Find Vehicle by Registration Number"),
        new(7, "Search Vehicles"),
        new(8, "Populate Garage with Test Data"),
        new(9, "Show Garage Information"),
        new(0, "Exit")
            ];

        public readonly Vehicle[] vehicles = [

            new Airplane
{
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