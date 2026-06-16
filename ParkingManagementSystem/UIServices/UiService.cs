using ParkingManagementSystem.Entities;
using ParkingManagementSystem.Factories;

namespace ParkingManagementSystem.UIServices
{
    public class UiService : IUiService
    {
        private readonly IUI _ui;
        private readonly IVehicleInputHandler _vehicleInputHandler;

        public UiService(IUI ui, IVehicleInputHandler vehicleInputHandler)
        {
            _ui = ui;
            _vehicleInputHandler = vehicleInputHandler;
        }

        public Vehicle UIAddVehicleService()
        {
            Vehicle vehicle = CreateVehicle();

            ReadCommonProperties(vehicle);

            ReadVehicleSpecificProperties(vehicle);

            return vehicle;
        }

        private Vehicle CreateVehicle()
        {
            Console.WriteLine("Available vehicle types:");
            Console.WriteLine("Car");
            Console.WriteLine("Motorcycle");
            Console.WriteLine("Bus");
            Console.WriteLine("Boat");
            Console.WriteLine("Airplane");

            while (true)
            {
                Console.Write("Vehicle type: ");

                VehicleType vehicleType =
                    _ui.ReadEnum<VehicleType>("vehicle type is required");

                try
                {
                    Vehicle vehicle =
                        _vehicleInputHandler.Create(vehicleType);

                    Console.Write("Registration number: ");

                    vehicle.RegistrationNumber =
                        _ui.ReadFromConsole(
                            "Registration number is required.");

                    return vehicle;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid vehicle type.");
                }
            }
        }

        private void ReadCommonProperties(Vehicle vehicle)
        {
            Console.Write("Color: ");

            string colorInput =
                _ui.ReadFromConsole("Color is required.");

            if (Enum.TryParse<Color>(colorInput, true, out Color color))
            {
                vehicle.Color = color;
            }

            Console.Write("Number of wheels: ");
            vehicle.NumberOfWheels =
                _ui.ReadNumeric<int>("Enter a valid number.");

            Console.Write("Weight: ");
            vehicle.Weight =
                _ui.ReadNumeric<double>("Enter a valid weight.");

            Console.Write("Max speed: ");
            vehicle.MaxSpeed =
                _ui.ReadNumeric<int>("Enter a valid speed.");
        }

        private void ReadVehicleSpecificProperties(Vehicle vehicle)
        {
            switch (vehicle)
            {
                case Car car:
                    ReadCarProperties(car);
                    break;

                case Motorcycle motorcycle:
                    ReadMotorcycleProperties(motorcycle);
                    break;

                case Bus bus:
                    ReadBusProperties(bus);
                    break;

                case Boat boat:
                    ReadBoatProperties(boat);
                    break;

                case Airplane airplane:
                    ReadAirplaneProperties(airplane);
                    break;
            }
        }

        private void ReadCarProperties(Car car)
        {
            Console.Write("Number of doors: ");
            car.NumberOfDoors =
                _ui.ReadNumeric<int>("Enter a valid number.");

            Console.Write("Fuel type: ");
            car.FuelType =
                _ui.ReadEnum<FuelType>("fuel type is required");
        }

        private void ReadMotorcycleProperties(Motorcycle motorcycle)
        {
            Console.Write("Cylinder volume: ");
            motorcycle.CylinderVolume =
                _ui.ReadNumeric<int>("Enter a valid number.");

            Console.Write("Has sidecar (y/n): ");

            motorcycle.HasSidecar =
                _ui.ReadFromConsole("")
                   .Equals("y", StringComparison.OrdinalIgnoreCase);
        }

        private void ReadBusProperties(Bus bus)
        {
            Console.Write("Number of seats: ");
            bus.NumberOfSeats =
                _ui.ReadNumeric<int>("Enter a valid number.");

            Console.Write("Double decker (y/n): ");

            bus.IsDoubleDecker =
                _ui.ReadFromConsole("")
                   .Equals("y", StringComparison.OrdinalIgnoreCase);
        }

        private void ReadBoatProperties(Boat boat)
        {
            Console.Write("Length: ");
            boat.Length =
                _ui.ReadNumeric<double>("Enter a valid length.");

            Console.Write("Hull type: ");
            boat.HullType =
                _ui.ReadFromConsole("");
        }

        private void ReadAirplaneProperties(Airplane airplane)
        {
            Console.Write("Number of engines: ");
            airplane.NumberOfEngines =
                _ui.ReadNumeric<int>("Enter a valid number.");

            Console.Write("Max altitude: ");
            airplane.MaxAltitude =
                _ui.ReadNumeric<int>("Enter a valid altitude.");
        }
    }
}

