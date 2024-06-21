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

        // This method is to generate report
        public void Status() {
            Console.WriteLine("Slot\tNo.\tType\tRegistration No\tColour");

            foreach (var slot in parkingSlots) {
                if (!slot.IsAvailable()) {
                    var vehicle = slot.Vehicle;
                    Console.WriteLine($"{slot.AvailableNumSlot}\t\t{vehicle.Type}\t{vehicle.PlateNumber}\t{vehicle.VehicleColor}");
                }
            }
        } 
    }
}