# Elevator Tycoon 🏢🛠️

[![.NET](https://github.com/nawa094/ElevatorTycoon/actions/workflows/dotnet.yml/badge.svg)](https://github.com/nawa094/ElevatorTycoon/actions/workflows/dotnet.yml)

Welcome to **Elevator Tycoon**, a .NET C# console application where you manage a fleet of elevators to efficiently transport passengers in a high-rise building. This project is designed to simulate real-world elevator behavior, including capacity management, destination queuing, and real-time updates. It’s a fun and educational way to explore asynchronous programming, event-driven design, and unit testing in C#.

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or higher)
- Git (optional, for cloning the repository)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/nawa094/ElevatorTycoon
   cd elevator-tycoon
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
  - Add elevators with custom capacities.
  - Simulate passenger pickups and drop-offs.
  - Real-time updates on elevator statuses.
  - Capacity management to prevent overloading.

### Commands

- **Add Elevators**: Add one or more elevators to the simulation.
- **Pick Up Passengers**: Simulate passengers requesting elevators from specific floors.
- **View Elevator Status**: Check the current status of all elevators (floor, direction, and passenger count).

---

## 🛠️ Technical Details

### Technologies Used

- **.NET 6**: The application is built using the latest .NET SDK.
- **Spectre.Console**: Handles all UI concerns, including display and prompts.
- **xUnit**: Used for writing unit tests.
- **Bogus**: Generates fake data for testing.
- **Shouldly**: Provides fluent assertions for unit tests.
- **FakeItEasy**: Used for mocking dependencies in unit tests.

### Key Features

1. **Asynchronous Elevator Management**:

   - Elevators process destinations asynchronously using `Channel<T>` for efficient task queuing.
   - Real-time updates are displayed using Spectre.Console.

2. **Capacity Management**:

   - Each elevator has a maximum capacity. Passengers are only assigned to elevators with available space.

3. **Unit Tests**:

   - Comprehensive unit tests ensure the reliability of the simulation logic.
   - Tests cover elevator behavior, capacity checks, and destination queuing.

4. **GitHub Actions**:
   - A CI/CD pipeline is set up to build and test the application on every push.

---

## 🧪 Running Unit Tests

To run the unit tests, navigate to the root of the repository and execute:

```bash
dotnet test
```

## 📂 Project Structure

```
elevator-tycoon/
├── ElevatorSimulator/          # Main console application
│   ├── Program.cs              # Entry point for the application
│   ├── Models/                 # Contains Elevator, Passenger, and other models
│   ├── Services/               # Contains ElevatorService and other services
│   └── Utils/                  # Helper classes and extensions
├── ElevatorSimulator.Tests/    # Unit tests for the application
│   ├── ElevatorTests.cs        # Tests for Elevator behavior
│   ├── ElevatorServiceTests.cs # Tests for ElevatorService logic
│   └── ...                     # Additional test files
├── .github/workflows/          # GitHub Actions workflow files
│   └── dotnet.yml              # CI/CD pipeline configuration
└── README.md                   # This file
```

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
