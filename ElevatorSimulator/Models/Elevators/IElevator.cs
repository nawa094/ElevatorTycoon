using ElevatorSimulator.Enums;

namespace ElevatorSimulator.Models.Elevators
{
    public interface IElevator
    {
        public Guid Id { get; set; }

        public Direction Direction { get; set; }

        public int CurrentFloor { get; set; }

        public int Capacity { get; set; }

        Task MoveToFloor(int floor);

        Task LoadPassangers(int passangerCount);

        Task UnloadPassangers(int passagerCount);
    }
}
