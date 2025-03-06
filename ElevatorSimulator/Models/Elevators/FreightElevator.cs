using ElevatorSimulator.Enums;

namespace ElevatorSimulator.Models.Elevators
{
    internal class FreightElevator : ElevatorBase
    {
        public FreightElevator(int maxCapacity, int speed, ElevatorType type, bool simulateMovement = true) : base(maxCapacity, speed, type, simulateMovement)
        {
        }
    }
}
