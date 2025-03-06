using ElevatorSimulator.Models.Elevators;

namespace ElevatorSimulator.Mappers
{
    internal static class ElevatorMappers
    {
        public static Status ToStatus(this IElevator elevator) => new ()
        {
            Id = elevator.Id,
            CurrentFloor = elevator.CurrentFloor,
            Direction = elevator.Direction.ToString(),
            NumberOfPassangers = elevator.NumberOfPassengers,
            ElevatorType = elevator.Type.ToString()
        };
    }
}
