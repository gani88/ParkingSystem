using ParkingSystem.Models;

namespace ParkingSystem.Services
{
    public class ManageParking {

        // Propery of this class
        private EmptyParking emptyParking;

        // Method to running all the logic/other method
        public void ParkInitiate() {

            while(true) {
                var doSth = Console.ReadLine();
                var sections = doSth.Split();

                switch(sections[0]) {
                    // To create park slot
                    case "create_parking_lot":
                        int size = int.Parse(sections[1]);
                        emptyParking = new EmptyParking(size);
                        Console.WriteLine($"Created a parking lot with {size} slots");
                        break;

                    // To park the vehicle
                    case "park":
                        var type = sections[3];
                        var vehicleColor = sections[2];
                        var plateNumber = sections[1];
                        var vehicle = new Vehicle(type, vehicleColor, plateNumber);

                        if (emptyParking.Park(vehicle, out int allocatedSlot)) {
                            Console.WriteLine($"Allocated slot number: {allocatedSlot}");
                        } else {
                            Console.WriteLine("Full");
                        }
                        break;
                    
                    // Generate the report
                    case "status":
                        emptyParking.Status();
                        break;

                    // Generate Lot that have been filled
                    case "show_filled":
                        emptyParking.CountFilledLot();
                        break;

                    // Generate Available Lot
                    case "show_emp_lot":
                        emptyParking.showEmptyLot();
                        break;

                    // Generate vehicle with even registration number
                    case "registration_numbers_for_vehicles_with_event_plate": case "even_plate":
                        emptyParking.OddOrEven(false);
                        break;

                    // Generate vehicle with odd registration number
                    case "registration_numbers_for_vehicles_with_ood_plate": case "odd_plate":
                        emptyParking.OddOrEven(true);
                        break;


                    // Generate vehicle based on vehicle type (car)
                    case "type_of":
                        var choose = Console.ReadLine();
                        if (choose == "Mobil") {
                            emptyParking.showType("Mobil");
                        } else {
                            emptyParking.showType("Motor");
                        }
                        break;

                    // Generate lot used by vehicle color
                    case "color_of":
                        var chooseColor = Console.ReadLine();
                        emptyParking.showLotByColor(chooseColor);
                        break;

                    // Exit Console/Program
                    case "exit":
                        return;

                    default:
                        Console.WriteLine("There is no such command");
                        break;
                }
            }
        }
    }
}