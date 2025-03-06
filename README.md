# Elevator Tycoon 🏢🛠️

[![.NET](https://github.com/nawa094/ElevatorTycoon/actions/workflows/dotnet.yml/badge.svg)](https://github.com/nawa094/ElevatorTycoon/actions/workflows/dotnet.yml)

Welcome to **Elevator Tycoon**, a .NET C# console application where you manage a fleet of elevators to efficiently transport passengers in a high-rise building. This project simulates real-world elevator behavior, including capacity management, destination queuing, and real-time updates. Along the way, it explores asynchronous programming, event-driven design, app configuration, and unit testing in C#.

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
  - Editable settings via `appsettings.json`.

### Commands

- **Pick Up Passengers**: Simulate passengers requesting elevators from specific floors.
- **View Elevator Status**: Check the current status of all elevators (floor, direction, type, and passenger count).

---

## 🛠️ Technical Details

### Technologies Used

- **.NET 8**: Core platform.
- **Spectre.Console**: Handles all UI, including menus and real-time output.
- **xUnit**: Unit testing framework.
- **Bogus**: Generates fake data for testing.
- **Shouldly**: Fluent assertions for tests.
- **FakeItEasy**: Mocks dependencies in unit tests.

---

## ⚙️ Configuration (New)

The application now supports configuration via `appsettings.json`, making it easy to adjust elevator behavior without touching code. Example:

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

### What You Can Customize

- Number of floors
- Maximum elevators
- Capacity for each elevator type
- Speed (milliseconds per floor) for each type

---

## 🔄 Recent Improvements & Future Reflections

### What’s New

- Introduced **appsettings.json** to externalize configuration.
- Added preliminary support for **different elevator types**: `Passenger`, `HighSpeed`, and `Freight`, each with unique capacities and speeds.

### What Could Be Better

- 🚀 **Elevator Allocation Logic**: Currently, elevator assignment doesn’t fully account for **elevator type suitability** (e.g., prioritizing freight for larger loads). This is a missed opportunity for smarter dispatching.
- 🔍 **Test Coverage**: While core flows are tested, there are **gaps around configuration loading** and **some edge cases in elevator prioritization**.
- 📊 **Code Coverage Insights**: Reviewing code coverage reports highlighted a few weak spots, particularly in how different elevator types are handled. More tests would make the logic more resilient.
- ⏩ **Shortcuts Taken**: To move faster, some areas (like deep polymorphism for elevators) were simplified. Revisiting this with a more **strategy-driven design** could improve flexibility and future features.

---

## 🧪 Running Unit Tests

To run the unit tests, simply execute:

```bash
dotnet test
```

---

## 📂 Project Structure

```
ElevatorSimulator/
├── Program.cs                  # Application entry point
├── appsettings.json             # Configurable settings (new)
├── Enums/                       # Direction, ElevatorType, etc.
├── Mappers/                     # Mapping logic (if needed)
├── Models/                      # Elevator, Passenger, Request, etc.
├── Presentation/                # UI components (menus, displays)
└── Services/                    # Core elevator logic (elevator management, dispatching)

ElevatorSimulator.Tests/
├── Enums/                       # Enum-specific tests
├── Mappers/                     # Mapper tests (if applicable)
├── Models/                      # Model behavior tests
├── Presentation/                # UI-related tests (where practical)
└── Services/                    # Service tests (elevator logic, dispatch, capacity checks)
```

---

## 📊 Assumptions

1. **Passengers share a destination floor**:
   - Each passenger group (pickup request) travels to a common floor.
2. **Elevator capacities are strictly enforced**:
   - No elevator can exceed its configured capacity.
3. **Stationary elevators are prioritized**:
   - Requests first look for idle elevators; otherwise, they match direction.
4. **Real-time output via Spectre.Console**:
   - Smooth, interactive updates via the console.
5. **Asynchronous processing with `Channel<T>`**:
   - Destination requests are handled concurrently.

---

## 🤝 Contributing

Contributions are always welcome! Whether it's refining the dispatch algorithm, improving test coverage, or enhancing the UI — your ideas are valuable.

1. Fork the repository.
2. Create a feature branch.
3. Commit changes with clear messages.
4. Open a pull request.

---

## 📜 License

This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.

---

## 🙏 Acknowledgments

Big thanks to:

- **Spectre.Console** for making CLI apps beautiful.
- **xUnit, Shouldly, Bogus, and FakeItEasy** for solid testing support.
- **The .NET Community** for providing such a rich development ecosystem.

---

## 🎉 Final Thoughts

**Elevator Tycoon** has been a great playground to blend **asynchronous programming**, **configuration management**, and **testing discipline** into a fun project. There’s plenty of room for growth — smarter elevator dispatch, finer control over elevator types, and richer simulation features (like maintenance mode, multi-floor requests, or even emergency scenarios). If that excites you, feel free to jump in and help make this the **ultimate elevator sim**.

---

**Happy coding — and may your elevators always arrive on time!** 🚀🏢
