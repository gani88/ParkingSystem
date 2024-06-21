using System;
using ParkingSystem.Services;

namespace ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var parkingSystem = new ManageParking();
            parkingSystem.ParkInitiate();
        }
    }
}
