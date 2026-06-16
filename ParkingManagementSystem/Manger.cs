using ParkingManagementSystem.Entities;
using ParkingManagementSystem.UIServices;
using ParkingManagementSystem.Utilites;

namespace ParkingManagementSystem
{
    public class Manager
    {
        private readonly IUI _ui;
        private readonly IHandler _handler;
        private readonly Dictionary<int, Action> _executeMethods;
        private readonly IUiService _uiService;

        public Manager(IHandler handler, IUI ui, IUiService uiService)
        {
            _handler = handler;
            _ui = ui;
            _uiService = uiService;
            _executeMethods = new Dictionary<int, Action>
{
    { 1, CreateGarage },
    { 2, ShowCapacity },
    { 3, ListVehicles },
    { 4, ListVehicleTypes },
    { 5, ParkVehicle },
    { 6, FindVehicle },
    { 7, SearchVehicles },
    { 8, UnParkVehicle },
    { 0, ExitApplication }
};
        }

        public void Start()
        {
            SeedGarage();
            Run();
        }

        private void Run()
        {
            while (true)
            {
                _ui.PrintMenu();

                int choice = _ui.ReadNumeric<int>("Please enter a valid number.");

                if (_executeMethods.TryGetValue(choice, out var action))
                {
                    action();
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();

                Console.Clear();
            }
        }

        public void SeedGarage()
        {
            if (_handler.GetParkedVehicles().Any())
                return;

            var seeder = new Seeder();

            foreach (var vehicle in seeder.vehicles)
            {
                _handler.ParkVehicle(vehicle);
            }
        }

        public void CreateGarage()
        {
            Console.WriteLine("enter capacity");
            int capacity = _ui.ReadNumeric<int>("Enter garage capacity:");

            _handler.CreateGarage(capacity);

            Console.WriteLine("Garage successfully created.");

        }
        private void SearchVehicles()
        {
            Console.Write("Color: ");
            var color = _ui.ReadEnum<Color>("Invalid color");

            Console.Write("Number of wheels: ");
            int wheels = _ui.ReadNumeric<int>("Invalid number");

            var result = _handler.SearchVehicles(v =>
                v.Color == color &&
                v.NumberOfWheels == wheels);

            if (!result.Any())
            {
                Console.WriteLine("No vehicle found ");
            }
            else
            {
                foreach (var vehicle in result)
                {
                    Console.WriteLine(vehicle.ToString());
                }
            }

        }

        private void ShowCapacity()
        {
            Console.WriteLine($"Capacity: {_handler.ParkCapacity()}");
        }

        private void ListVehicles()
        {
            var vehicles = _handler.GetParkedVehicles();

            if (!vehicles.Any())
            {
                Console.WriteLine("No vehicles parked.");
                return;
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }

        private void ListVehicleTypes()
        {
            foreach (var item in _handler.GetTotalParkedType())
            {
                Console.WriteLine($"Type: { item.VehicleType},Total: { item.Count}");
            }
        }

        private void ParkVehicle()
        {
            Vehicle vehicle = _uiService.UIAddVehicleService();

            bool parked = _handler.ParkVehicle(vehicle);

            Console.WriteLine(
                parked
                    ? "Vehicle parked successfully."
                    : "Garage is full or vehicle already exists.");
        }
        private void FindVehicle()
        {
            Console.Write("Registration number: ");

            string regNo =
                _ui.ReadFromConsole("Enter a valid registration number.");

            var vehicle = _handler.GetVehicle(regNo);

            if (vehicle is null)
            {
                Console.WriteLine("Vehicle not found.");
                return;
            }

            Console.WriteLine(vehicle.ToString());
        }

        private void UnParkVehicle()
        {
            Console.Write("Registration number: ");

            string regNo =
                _ui.ReadFromConsole("Enter a valid registration number.");

            bool removed = _handler.UnParkVehicle(regNo);

            Console.WriteLine(
                removed
                    ? "Vehicle removed successfully."
                    : "Vehicle not found.");
        }
        private void ExitApplication()
        {
            Environment.Exit(0);
        }
    }
}