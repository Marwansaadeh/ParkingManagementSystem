using ParkingManagementSystem;
using ParkingManagementSystem.Entities;
using ParkingManagementSystem.Factories;
using ParkingManagementSystem.UIServices;
using ParkingManagementSystem.UIServices.ParkingManagementSystem.UIServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//IVehicleInputHandler vehicleInputHandler = new VehicleInputHandler();
//IUI uI = new UI();
//IUiService uiService = new UiService(uI,vehicleInputHandler);
//IGarage<Vehicle> garage = new Garage<Vehicle>(100);
//IHandler handler = new Handler(garage);
//Manager manager = new(handler,uI,uiService);
//manager.Start();

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IUI, UI>();

        services.AddSingleton<IVehicleInputHandler, VehicleInputHandler>();

        services.AddSingleton<IUiService, UiService>();

        services.AddSingleton<IGarage<Vehicle>>(sp =>
            new Garage<Vehicle>(100));

        services.AddSingleton<IHandler, Handler>();

        services.AddSingleton<Manager>();
    })
    .UseConsoleLifetime()
    .Build();

var manager = host.Services.GetRequiredService<Manager>();
manager.Start();