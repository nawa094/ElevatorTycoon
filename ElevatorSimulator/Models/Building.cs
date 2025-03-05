using ElevatorSimulator.Controllers;

namespace ElevatorSimulator.Models
{
    public class Building
    {
        private int _floors;
        private readonly IElevatorController _controller;

        private Building(int numberOfFloors, int numberOfElevators)
        {
            _floors = numberOfFloors;
            _controller = ElevatorController.Create(numberOfElevators);
        }

        public void PickUpPassangers(int fromFloor, int toFloor, int passangerCount = 1)
        {
            Task.Run(() => _controller.PickUpPassanger(fromFloor, new List<Passanger> { new Passanger { DestinationFloor = toFloor, Id = 1 } }));
        }

        public void GetElevatorStatuses() => _controller.GetElevatorStatus();

        public static Building Create(int numberOfFloors, int numberOfElevators)
        {
            return new Building(numberOfFloors, numberOfElevators);
        }
    }
}
