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
        public void OddOrEven(bool isEven) {
            
            var vehicle = new List<String>();

            foreach (var slot in parkingSlots) {
                if (slot.Vehicle != null) {
                    var parts = slot.Vehicle.PlateNumber.Split('-');
                    if (parts.Length > 1 && parts[1].Length > 0 && char.IsDigit(parts[1][0])) {
                        int num = parts[1][0] - '0';

                        if (num % 2 == 0 == isEven) {
                            vehicle.Add(slot.Vehicle.PlateNumber);
                        }
                    }
                }
            }

            Console.WriteLine($"Total vehicles : {vehicle.Count}");
            Console.WriteLine(String.Join(", ", vehicle));
        }

        

    }
}