using ParkingManagementSystem.Entities;
using ParkingManagementSystem.Utilites;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ParkingManagementSystem
{
    public class Manger
    {
        private readonly IUI _ui;
        private readonly IHandler _handler;
        private Dictionary<int, Action> _executeMethods;
        public Manger(IHandler handler, IUI ui)
        {
             _handler= handler;
            _ui = ui;
            _executeMethods = new Dictionary<int, Action>
{
    { 1, () => Console.WriteLine($"Capacity: {_handler.ParkCapacity()}") },

    { 2, () =>
        {
            if( _handler != null ){
            foreach (var vehicle in _handler.GetParkedVehicles())
            {
               Console.WriteLine(vehicle.ToString());
            }
            }else{
            Console.WriteLine("No vheicles");
            }
        }
    },

    { 3, () =>
        {
            
            foreach (var item in _handler.GetTotalParkedType())
            {
                Console.WriteLine($"{item}");
            }
        }
    },

    { 4, () =>
        {
            _handler.ParkVehicle(new Car(){
            Color="read",
            RegistrationNumber ="Abc"
            });
        }
    },

    { 5, () =>
        {
            Console.Write("Registration number: ");
            var regNo = _ui.ReadFromConsole("enter a valid registeration number");

            var vehicle = _handler.GetVehicle(regNo);

            Console.WriteLine(vehicle.ToString() ?? "Vehicle not found");
        }
    },

    { 6, () =>
        {
            Console.Write("Registration number: ");
            var regNo = Console.ReadLine();

            var removed = _handler.RemoveVehicle(regNo);

            Console.WriteLine(removed
                ? "Vehicle removed"
                : "Vehicle not found");
        }
    }
};
        }

        public void Star()
        {
            _ui.PrintMenu();
        }
        public void Run() {

            int count = _handler.GetParkedVehicles().Count();
            if (count == 0)
            {
                var seeder = new Seeder().vehicles;
                foreach (var item in seeder)
                {
                    _handler.ParkVehicle(item);
                }
            }

            while (true)
            {
                int userChooice = _ui.ReadNumeric<int>("please enter a valid number");

                if (_executeMethods.TryGetValue(userChooice, out var action))
                {
                    action();
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
        }
    }
}
