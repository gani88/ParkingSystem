using ParkingSystem.Models;
using System;

namespace ParkingSystem.Services {
    public class ParkingSystem {

        // Propery of this class
        private EmptyParking emptyParking;

        // Method to running all the logic/other method
        public void ParkInitiate() {

            while(true) {
                var doSth = Console.ReadLine();
                var sections = doSth.Split();

                switch(sections[0]) {
                    case "create_parking_lot":
                        int size = int.Parse(sections[1]);
                        emptyParking = new EmptyParking(size);
                        Console.WriteLine($"Created a parking lot with {size} slots");
                        break;

                    case "park":
                        var type = sections[1];
                        var vehicleColor = sections[2];
                        var plateNumber = sections[3];
                        var vehicle = new Vehicle(type, vehicleColor, plateNumber);

                        if (emptyParking.Park(vehicle, out int allocatedSlot)) {
                            Console.WriteLine($"Allocated slot number: {allocatedSlot}");
                        } else {
                            Console.WriteLine("Full");
                        }
                        break;
                    
                    case "status":
                        emptyParking.Status();
                        break;

                    case "exit":
                        return;
                }
            }
        }
    }
}