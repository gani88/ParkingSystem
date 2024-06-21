using ParkingSystem.Models;


namespace ParkingSystem.Services 
{
    // This class contain methods to handle empty lot
    public class EmptyParking {
        private List<ParkingSlot> parkingSlots;

        // Method to allocate slot/lot
        public EmptyParking(int numSlots) {
            parkingSlots = new List<ParkingSlot>();

            for (int i=1; i <= numSlots; i++ ) {
                parkingSlots.Add(new ParkingSlot(i));
            }
        }

        // Method to park the vehicle/occupy the slot/lot
        public bool Park(Vehicle vehicle, out int allocatedSlot) {
            foreach (var slot in parkingSlots) {
                if (slot.IsAvailable()) {
                    slot.Vehicle = vehicle;
                    allocatedSlot = slot.AvailableNumSlot;
                    return true; // Meaning the vehicle park successfully
                }
            }
            
            allocatedSlot = -1;
            return false;
        }

        // Method to generate report
        public void Status() {
            Console.WriteLine("Slot\tNo.\tType\tRegistration No\tColour");

            foreach (var slot in parkingSlots) {
                if (!slot.IsAvailable()) {
                    var vehicle = slot.Vehicle;
                    Console.WriteLine($"{slot.AvailableNumSlot}\t\t{vehicle.Type}\t{vehicle.PlateNumber}\t{vehicle.VehicleColor}");
                }
            }
        }

        // Method to check the plate/registration number odd / even
        public void OddOrEven(bool isOdd) {
            
            var vehicleOdd = new List<String>();
            var vehicleEven = new List<String>();

            foreach (var slot in parkingSlots) {
                if (slot.Vehicle != null) {

                    // Split the Registration Number Format (Ex : [])
                    var parts = slot.Vehicle.PlateNumber.Split('-');
                    if (parts.Length > 1 && parts[1].Length > 0 && char.IsDigit(parts[1][0])) {
                        int num = parts[1][3] - '0';

                        if (num % 2 == 1) {
                            vehicleOdd.Add(slot.Vehicle.PlateNumber);
                        } else if (num % 2 == 0) {
                            vehicleEven.Add(slot.Vehicle.PlateNumber);

                        }
                    }
                }
            }

            if (isOdd == true) {
                Console.WriteLine($"Total vehicles : {vehicleOdd.Count}");
                Console.WriteLine(String.Join(", ", vehicleOdd));
            } else {
                Console.WriteLine($"Total vehicles : {vehicleEven.Count}");
                Console.WriteLine(String.Join(", ", vehicleEven));
            }
            
        }
    }
}