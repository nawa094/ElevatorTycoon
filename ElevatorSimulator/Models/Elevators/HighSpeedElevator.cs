using ElevatorSimulator.Enums;

namespace ElevatorSimulator.Models.Elevators
{
    internal class HighSpeedElevator : ElevatorBase
    {
        public HighSpeedElevator(int maxCapacity, int speed, ElevatorType type, bool simulateMovement = true) : base(maxCapacity, speed, type, simulateMovement)
        {
        }
    }
}
