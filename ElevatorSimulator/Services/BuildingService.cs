using ElevatorSimulator.Mappers;
using ElevatorSimulator.Models;
using ElevatorSimulator.Models.Elevators;

namespace ElevatorSimulator.Services
{
    public interface IBuildingService
    {
        void PickUpPassangers(int fromFloor, int toFloor, int passangerCount = 1);

        IReadOnlyCollection<Status> GetElevatorStatuses();

        void AddElevators(int numberOfElevators);
    }

    public class BuildingService : IBuildingService
    {
        private readonly IElevatorService _elevatorService;

        public BuildingService(IElevatorService service)
        {
            _elevatorService = service;
        }

        public void PickUpPassangers(int fromFloor, int toFloor, int passangerCount = 1)
        {
            var passangers = Enumerable.Range(0, passangerCount).Select(i => new Passanger { Id = i, DestinationFloor = toFloor });

            Task.Run(() => _elevatorService.PickUpPassanger(fromFloor, passangers));
        }

        public IReadOnlyCollection<Status> GetElevatorStatuses() 
        {
            var elevators = _elevatorService.GetElevators();

            return elevators.Select(e => e.ToStatus()).ToList().AsReadOnly();
        }

        public void AddElevators(int numberOfElevators)
        {
            var passangerElevators = Enumerable.Range(0, numberOfElevators).Select(i => new PassangerElevator());

            _elevatorService.AddElevators(passangerElevators);
        }
    }
}
