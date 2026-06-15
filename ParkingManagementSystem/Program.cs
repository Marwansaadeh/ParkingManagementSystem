using ParkingManagementSystem;
using ParkingManagementSystem.Entities;
using ParkingManagementSystem.UIServices;

IUI uI = new UI();
IUiService uiService = new UiService(uI);
IGarage<Vehicle> garage = new Garage<Vehicle>(100);
IHandler handler = new Handler(garage);
Manager manager = new(handler,uI,uiService);
manager.Start();