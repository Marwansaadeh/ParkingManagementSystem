using ParkingManagementSystem;
using ParkingManagementSystem.Entities;
IGarage<Vehicle> garage = new Garage<Vehicle>(5);
IUI uI = new UI();
IHandler handler = new Handler(garage);
Manger manager = new(handler,uI);
manager.Star();
manager.Run();