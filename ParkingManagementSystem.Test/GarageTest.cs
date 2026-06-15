using ParkingManagementSystem.Entities;
using ParkingManagementSystem.Utilites;

namespace ParkingManagementSystem.Test
{
    public class GarageTest
    {
        private readonly Seeder seeder = new Seeder();
        private readonly Garage<Vehicle> garage;
        private readonly Vehicle vehicle;

        public GarageTest()
        {
            garage = new Garage<Vehicle>(1);
            vehicle = seeder.vehicles[0];
        }

        [Fact]
        public void Park_WhenPassVehicle_Should_ReturnTrue()
        {
            bool result = garage.Park(vehicle);

            Assert.True(result);
        }

        [Fact]
        public void Park_WhenPassVehicleWithNoCapacity_Should_Returnfalse()
        {
            var garage = new Garage<Vehicle>(0);
            var vehicle = seeder.vehicles[0];

            bool result = garage.Park(vehicle);

            Assert.False(result);
        }

    }
}
