using ElevatorSimulator.Enums;

namespace ElevatorSimulator.Models.Elevators
{
    internal class PassangerElevator : ElevatorBase
    {
        public PassangerElevator(int maxCapacity, int speed, ElevatorType type, bool simulateMovement = true) : base(maxCapacity, speed, type, simulateMovement)
        {
        }
    }
}
