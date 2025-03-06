# Elevator Tycoon 🏢🛠️

[![.NET](https://github.com/nawa094/ElevatorTycoon/actions/workflows/dotnet.yml/badge.svg)](https://github.com/nawa094/ElevatorTycoon/actions/workflows/dotnet.yml)

Welcome to **Elevator Tycoon**, a .NET C# console application where you manage a fleet of elevators to efficiently transport passengers in a high-rise building. This project simulates real-world elevator behavior, including capacity management, destination queuing, and real-time updates. It’s a fun and educational way to explore asynchronous programming, event-driven design, configuration management, and unit testing in C#.

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or higher)
- Git (optional, for cloning the repository)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/nawa094/ElevatorTycoon
   cd ElevatorTycoon
   ```

2. Restore the dependencies:

   ```bash
   dotnet restore
   ```

3. Run the application:

   ```bash
   cd ElevatorSimulator
   dotnet run
   ```

   Follow the on-screen prompts to interact with the simulation.

---

## 🎮 How to Play

### Game Overview

- **Objective**: Manage a fleet of elevators to efficiently transport passengers to their desired floors.
- **Features**:
  - Add elevators with custom capacities and speeds.
  - Simulate passenger pickups and drop-offs.
  - Real-time updates on elevator statuses.
  - Capacity management to prevent overloading.
  - Configurable building and elevator settings.

### Commands

- **Pick Up Passengers**: Simulate passengers requesting elevators from specific floors.
- **View Elevator Status**: Check the current status of all elevators (floor, direction, and passenger count).

---

## 🛠️ Technical Details

### Technologies Used

- **.NET 8**: The application is built using the latest .NET SDK.
- **Spectre.Console**: Handles all UI concerns, including display and prompts.
- **IOptions Pattern**: Configuration is loaded using `appsettings.json`, allowing users to tweak building and elevator settings.
- **xUnit**: Used for writing unit tests.
- **Bogus**: Generates fake data for testing.
- **Shouldly**: Provides fluent assertions for unit tests.
- **FakeItEasy**: Used for mocking dependencies in unit tests.

---

## ⚙️ Configuration

The application reads settings from **`appsettings.json`**, which allows you to customize the simulation without modifying code. These settings include:

```json
{
  "ElevatorSettings": {
    "MaxFloors": 163,
    "MaxElevators": 10,
    "ElevatorCapacities": {
      "Passenger": 10,
      "HighSpeed": 8,
      "Freight": 20
    },
    "ElevatorSpeeds": {
      "Passenger": 1000,
      "HighSpeed": 1700,
      "Freight": 750
    }
  }
}
```

Users are free to **edit this file** to match the building and elevator configuration they want to simulate.

---

## 🔬 Key Features

### 1. Asynchronous Elevator Management

- Elevators process destinations asynchronously using `Channel<DestinationDetails>` for efficient and thread-safe task queuing.
- Real-time updates are displayed using **Spectre.Console**.

### 2. Capacity and Speed Management

- Each elevator type has configurable:
  - **Capacity** (number of passengers).
  - **Speed** (milliseconds per floor).
- These are loaded from `appsettings.json`, making the simulation adaptable to different building types.

### 3. Configuration via `IOptions`

- `ElevatorSettings` is strongly typed and injected using the **Options pattern**, ensuring clean separation between configuration and business logic.

### 4. Unit Tests

- Comprehensive unit tests cover elevator behavior, capacity checks, and destination queuing.
- Tests are written using **xUnit**, with help from **Shouldly**, **Bogus**, and **FakeItEasy**.

### 5. GitHub Actions CI/CD

- Every push triggers an automated **build** and **test run** via **GitHub Actions**.

---

## 🧪 Running Unit Tests

To run the unit tests, navigate to the root of the repository and execute:

```bash
dotnet test
```

---

## 📂 Project Structure

ElevatorSimulator (Main Project)

```
ElevatorSimulator/
├── Program.cs                  # Entry point for the application
├── appsettings.json             # Contains configurable elevator and building settings
├── Enums/                       # Contains enums (e.g., Direction)
├── Mappers/                     # Contains mapping logic (if applicable)
├── Models/                      # Contains Elevator, Passenger, and other models
├── Presentation/                # Contains UI-related classes (e.g., menus, prompts)
└── Services/                    # Contains ElevatorService and other services
```

ElevatorSimulator.Tests (Test Project)

```
ElevatorSimulator.Tests/
├── Enums/                       # Tests for enums
├── Mappers/                     # Tests for mapping logic
├── Models/                      # Tests for Elevator, Passenger, and other models
├── Presentation/                # Tests for UI-related classes
└── Services/                    # Tests for ElevatorService and other services
```

---

## ⚠️ Known Shortcuts and Future Work

In the interest of time, a few design shortcuts were taken:

- **Elevator Types**: The handling of different elevator types (Passenger, HighSpeed, Freight) could be improved, I didn't like the ElevatorType constructor parameter. This would make type-specific logic cleaner.
- **Code Coverage Report**: Reviewing the code coverage report showed a few gaps in test coverage. Adding tests for edge cases (like elevators being full or handling simultaneous requests) would improve overall confidence.
- **Settings Validation**: Adding a configuration validation step would ensure that invalid configurations (negative floors, zero capacity elevators) are caught at startup.

These are all **opportunities for future improvement**, and contributions in these areas are welcome!

---

## 🤝 Contributing

Contributions are welcome! If you’d like to contribute, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Commit your changes and push to your branch.
4. Submit a pull request.

---

## 📜 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## 🙏 Acknowledgments

- **Spectre.Console**: For making console applications beautiful and interactive.
- **xUnit, Shouldly, Bogus, and FakeItEasy**: For enabling robust unit testing.
- **.NET Community**: For providing an amazing ecosystem to build on.

---

Enjoy managing your elevators and optimizing passenger flow in **Elevator Tycoon**! If you have any questions or feedback, feel free to open an issue or reach out.

Happy coding! 🎉

---
