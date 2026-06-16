using ParkingManagementSystem.Entities;


namespace ParkingManagementSystem
{
    public interface IGarage<T> : IEnumerable<T> where T : Vehicle
    {
        bool Park(T vehicle);
        bool UnPark(string registrationNumber);
        int Capacity { get; }
        int Count { get; }
    }
}
