using ParkingManagementSystem.Entities;
using ParkingManagementSystem.Utilites;

namespace ParkingManagementSystem.Test
{

    public class GarageTest
    {
        private readonly Seeder seeder = new Seeder();
        private readonly Garage<Vehicle> garage;

        public GarageTest()
        {
            garage = new Garage<Vehicle>(10);

            foreach (var item in seeder.vehicles)
            {
                garage.Park(item);
            }
        }

        [Fact]
        public void Park_ValidVehicle_ReturnsTrue()
        {
            var garage = new Garage<Vehicle>(10);
            var vehicle = seeder.vehicles[0];

            bool result = garage.Park(vehicle);

            Assert.True(result);
        }

        [Fact]
        public void Park_GarageIsFull_ReturnsFalse()
        {
            var garage = new Garage<Vehicle>(0);
            var vehicle = seeder.vehicles[0];

            bool result = garage.Park(vehicle);

            Assert.False(result);
        }

        [Fact]
        public void Park_ValidVehicle_IncreasesCountByOne()
        {
            var garage = new Garage<Vehicle>(3);
            var vehicle = seeder.vehicles[0];

            garage.Park(vehicle);

            Assert.Equal(1, garage.Count);
        }

        [Fact]
        public void Park_DuplicateVehicle_DoesNotIncreaseCount()
        {
            var garage = new Garage<Vehicle>(3);
            var vehicle = seeder.vehicles[0];

            garage.Park(vehicle);
            garage.Park(vehicle);

            Assert.Equal(1, garage.Count);
        }

        [Fact]
        public void Park_DuplicateVehicle_ReturnsFalse()
        {
            var garage = new Garage<Vehicle>(3);
            var vehicle = seeder.vehicles[0];

            garage.Park(vehicle);

            bool result = garage.Park(vehicle);

            Assert.False(result);
            Assert.Equal(1, garage.Count);
        }

        [Fact]
        public void UnPark_ExistingVehicle_DecreasesCountToZero()
        {
            var garage = new Garage<Vehicle>(3);
            var vehicle = seeder.vehicles[0];

            garage.Park(vehicle);
            garage.UnPark(vehicle.RegistrationNumber);

            Assert.Equal(0, garage.Count);
        }

        [Fact]
        public void UnPark_NullRegistrationNumber_ThrowsArgumentException()
        {
            var garage = new Garage<Vehicle>(3);

            var exception = Assert.Throws<ArgumentException>(
                () => garage.UnPark(null!));

            Assert.Equal("registrationNumber", exception.ParamName);
        }

        [Fact]
        public void UnPark_UnknownRegistrationNumber_ReturnsFalse()
        {
            bool result = garage.UnPark("SE-ABCx");

            Assert.False(result);
        }
    }
}
