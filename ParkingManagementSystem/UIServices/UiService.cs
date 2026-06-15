using ParkingManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingManagementSystem.UIServices
{
    public class UiService:IUiService
    {
        private readonly IUI _iUi;
        public UiService( IUI Iui)
        {
            _iUi= Iui;
        }

        public Vehicle UIAddVehicleService()
        {
            var factories = new Dictionary<string, Func<Vehicle>>(StringComparer.OrdinalIgnoreCase)
            {
                ["Car"] = () => new Car(),
                ["Motorcycle"] = () => new Motorcycle(),
                ["Bus"] = () => new Bus(),
                ["Boat"] = () => new Boat(),
                ["Airplane"] = () => new Airplane()
            };

            Console.WriteLine("Available vehicle types:");

            foreach (var type in factories.Keys)
                Console.WriteLine(type);

            Console.Write("Vehicle type: ");
            string vehicleType = _iUi.ReadFromConsole("Vehicle type is required.");

            Func<Vehicle>? factory = null;

            while (!factories.TryGetValue(vehicleType, out factory))
            {
                Console.WriteLine("Invalid vehicle type.");
                Console.Write("Vehicle type: ");
                vehicleType = _iUi.ReadFromConsole("Vehicle type is required.");
            }


            Console.Write("Registration number: ");
            string registrationNumber =
                _iUi.ReadFromConsole("Registration number is required.");

            Vehicle vehicle = factory();

            vehicle.RegistrationNumber = registrationNumber;

            Console.Write("Color (Enter to skip): ");
            vehicle.Color = _iUi.ReadFromConsole("");

            Console.Write("Number of wheels (Enter to skip): ");
            vehicle.NumberOfWheels = _iUi.ReadNumeric<int>("");

            Console.Write("Weight (Enter to skip): ");
            vehicle.Weight = _iUi.ReadNumeric<double>("");

            Console.Write("Max speed (Enter to skip): ");
            vehicle.MaxSpeed = _iUi.ReadNumeric<int>("");

            switch (vehicle)
            {
                case Car car:

                    Console.Write("Number of doors (Enter to skip): ");
                    car.NumberOfDoors = _iUi.ReadNumeric<int>("");

                    Console.Write("Fuel type (Enter to skip): ");
                    car.FuelType =
                        _iUi.ReadOptionalEnum<FuelType>() ?? default;

                    break;

                case Motorcycle motorcycle:

                    Console.Write("Cylinder volume (Enter to skip): ");
                    motorcycle.CylinderVolume =
                        _iUi.ReadNumeric<int>("");

                    Console.Write("Has sidecar (y/n, Enter to skip): ");
                    string? sidecar = _iUi.ReadFromConsole("");

                    if (sidecar != null)
                        motorcycle.HasSidecar =
                            sidecar.Equals("y",
                            StringComparison.OrdinalIgnoreCase);

                    break;

                case Bus bus:

                    Console.Write("Number of seats (Enter to skip): ");
                    bus.NumberOfSeats =
                        _iUi.ReadNumeric<int>("");

                    Console.Write("Double decker (y/n, Enter to skip): ");
                    string? doubleDecker = _iUi.ReadFromConsole("");

                    if (doubleDecker != null)
                        bus.IsDoubleDecker =
                            doubleDecker.Equals("y",
                            StringComparison.OrdinalIgnoreCase);

                    break;

                case Boat boat:

                    Console.Write("Length (Enter to skip): ");
                    boat.Length =
                        _iUi.ReadNumeric<double>("");

                    Console.Write("Hull type (Enter to skip): ");
                    boat.HullType =_iUi.ReadFromConsole("");

                    break;

                case Airplane airplane:

                    Console.Write("Number of engines (Enter to skip): ");
                    airplane.NumberOfEngines =
                        _iUi.ReadNumeric<int>("");

                    Console.Write("Max altitude (Enter to skip): ");
                    airplane.MaxAltitude =
                       _iUi.ReadNumeric<int>("");

                    break;
            }

            return vehicle;
        }

    }
           
    }

