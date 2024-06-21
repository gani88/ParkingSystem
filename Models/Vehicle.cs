namespace ParkingSystem.Models 

{
    // Class for entity Vehicle (Car & Motorcycle)
    public class Vehicle {
        public string Type { get; set; }
        public string VehicleColor { get; set; }
        public string PlateNumber { get; set; }

        // Constructor for this class
        public Vehicle(string type, string vehicleColor, string plateNumber) {
            this.Type = type;
            this.VehicleColor = vehicleColor;
            this.PlateNumber = plateNumber;
        }
    }
}