namespace ElevatorSimulator.Services
{
    public interface IBuildingService
    {
        void PickUpPassangers(int fromFloor, int toFloor, int passangerCount = 1);

        void GetElevatorStatuses();
    }

    public class BuildingService : IBuildingService
    {
        private readonly IElevatorService _controller;

        public BuildingService(IElevatorService controller)
        {
            _controller = controller;
        }

        public void PickUpPassangers(int fromFloor, int toFloor, int passangerCount = 1)
        {
            Task.Run(() => _controller.PickUpPassanger(fromFloor, [new() { DestinationFloor = toFloor, Id = 1 }]));
        }

        public void GetElevatorStatuses() => _controller.GetElevatorStatus();
    }
}
