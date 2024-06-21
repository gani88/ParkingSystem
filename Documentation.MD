# System Parking Management Using .NET

## Background
This system is designed to manage, track, and generate reports about vehicle parking. 
It uses lot system, each lot can contain one car or one motorcycle, and one person only have one lot.


## Features
### Check In
- All vehicles can use available lot
- Only car and motorcycle that can used it
- Each vehicle that used the lot will be tracked the plate number/registration number
- Cost of the parking is based on per hour. Immediately affect from first hour.

### Check out
- Lot can be used again by another vehicle if the earlier vehicle already left the lot

### Report 
- Report of filled lot
- Report of available lot
- Report based odd and even registration number
- Report based on color of vehicle
- Report based on type of vehicle

## Project Structure
The project is structured into multiple namespaces, classes.

```
ParkingSystem
├── Program.cs
├── Models
│   ├── Vehicle.cs
│   ├── ParkingSlot.cs
├── Services
│   ├── EmptyParking.cs
│   ├── ManageParking.cs
└── Documentation.MD
```
### ParkingSystem

#### `Program`
This is main class that initiates the project.
- **Methods** : 
    - `Main(string[] args)`: The only route of the application. Creates instance of `ManageParking` and initiates the parking system.

### Models

#### `Vehicle`
- **Properties**:
  - `Type` (string): The type of the vehicle (Car & Motorcycle).
  - `VehicleColor` (string): The color of the vehicle.
  - `PlateNumber` (string): The plate number of the vehicle.
- **Constructor**:
  - `Vehicle(string type, string vehicleColor, string plateNumber)`: Initializes a new instance of the `Vehicle` class with the specified type, color, and plate number.

#### `ParkingSlot`
- Represents a parking slot which may be available or occupied by a vehicle.
- **Properties**:
  - `AvailableNumSlot` (int): The slot number.
  - `Vehicle` (Vehicle?): The vehicle currently occupying the slot, can be null.
- **Constructor**:
  - `ParkingSlot(int availableNumSlot)`: Initializes a new instance of the `ParkingSlot` class with the specified slot number.
- **Methods**:
  - `IsAvailable()`: Checks if the slot is available.
  - `IsLeave()`: Marks the slot as available by removing the occupying vehicle.

  ### Services
  
  #### `EmptyParking`
  - Manages how the Parking System Work, where the feature reside.
- **Properties**:
  - `List<ParkingSlot>`: A list of parking slots.
- **Constructor**:
  - `EmptyParking(int numSlots)`: Initializes a new instance of the `EmptyParking` class with the specified number of slots.
- **Methods**:
  - `Park(Vehicle vehicle, out int allocatedSlot)`: Attempts to park a vehicle in an available slot/allocate slot.
  - `Status()`: Generates a report of the current status of all parking slots.
  - `OddOrEven(bool isOdd)`: Generates a report of vehicles with odd or even registration numbers.
  - `CountFilledLot()`: Generates a report of filled parking slots.
  - `showEmptyLot()`: Generates a report of available parking slots.
  - `showType(string vehicleType)`: Generates a report of parking slots occupied by a specific type of vehicle.
  - `showLotByColor(string color)`: Generates a report of parking slots occupied by vehicles of a specific color.
  - `Leave(int lotNum)`: Frees up a parking slot when a vehicle leaves.

#### `ManageParking`
  - This class is the place for user input, including handling the switch
- **Methods**:
  - `ParkInitiate()`: Main method to run the parking management logic and process user commands.