namespace ParkingSystem.Models 
{
    // Class for slot of parking, contain available slot and vehicle that using it
    public class ParkingSlot {
        public int AvailableNumSlot { get; set; }
        public Vehicle? Vehicle { get; set; }

        // Constructor
        public ParkingSlot(int availableNumSlot) {
            this.AvailableNumSlot = availableNumSlot;
            this.Vehicle = null;
        }

        // Method to check availability parking slot
        public bool IsAvailable() {
            return Vehicle == null;
        }
    }
}