using ElevatorSimulator.Enums;

namespace ElevatorSimulator.Models.Elevators
{
    public interface IElevator
    {
        public string Id { get; set; }

        public Direction Direction { get; set; }

        public int CurrentFloor { get; set; }

        Task MoveToFloor(int floor);

        Task LoadPassangers(int passangerCount);

        Task UnloadPassangers(int passagerCount);
    }
}
