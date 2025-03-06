using ElevatorSimulator.Builder;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Mappers;
using ElevatorSimulator.Models.Elevators;

namespace ElevatorSimulator.Services
{
    public interface IBuildingService
    {
        void PickUpPassangers(int fromFloor, int toFloor, int passangerCount);

        IReadOnlyCollection<Status> GetElevatorStatuses();

        void AddElevators(Dictionary<ElevatorType, int> elevatorSelection);
    }

    public class BuildingService : IBuildingService
    {
        private readonly IElevatorService _elevatorService;
        private readonly IElevatorBuilder _builder;

        public BuildingService(IElevatorService service, IElevatorBuilder builder)
        {
            _elevatorService = service;
            _builder = builder;
        }

        public void PickUpPassangers(int fromFloor, int toFloor, int passangerCount)
        {
            Task.Run(() => _elevatorService.PickUpPassenger(fromFloor, toFloor, passangerCount));
        }

        public IReadOnlyCollection<Status> GetElevatorStatuses() 
        {
            var elevators = _elevatorService.GetElevators();

            return elevators.Select(e => e.ToStatus()).ToList().AsReadOnly();
        }

        public void AddElevators(Dictionary<ElevatorType, int> elevatorSelection)
        {
            foreach(var selection in elevatorSelection)
            {
                var elevators = Enumerable.Range(0, selection.Value).Select(i => _builder.Build(selection.Key));

                _elevatorService.AddElevators(elevators);
            }
        }
    }
}
