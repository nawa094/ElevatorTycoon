using ElevatorSimulator.Enums;
using ElevatorSimulator.Models;
using ElevatorSimulator.Models.Elevators;

namespace ElevatorSimulator.Services
{
    public interface IElevatorService
    {
        Task PickUpPassanger(int fromFloor, IEnumerable<Passanger> passangers);

        IReadOnlyCollection<IElevator> GetElevators();
        void AddElevators<T>(IEnumerable<T> elevators) where T : IElevator;
        void AddElevator<T>(T elevator) where T : IElevator;
    }

    public class ElevatorService : IElevatorService
    {
        private static List<IElevator> _elevators = new();

        public IReadOnlyCollection<IElevator> GetElevators()
        {
            return _elevators.AsReadOnly();
        }

        public async Task PickUpPassanger(int fromFloor, IEnumerable<Passanger> passangers)
        {
            var elevator = GetNearestElevator(fromFloor);

            // pick up passangers
            await elevator.MoveToFloor(fromFloor);
            await elevator.LoadPassangers(passangers.Count());

            foreach (var p in passangers)
            {
                await elevator.MoveToFloor(p.DestinationFloor);
                await elevator.UnloadPassangers(1);
            }
        }

        public void AddElevators<T>(IEnumerable<T> elevators) where T : IElevator
        {
            foreach(var elevator in elevators)
            {
                AddElevator(elevator);
            }
        }

        public void AddElevator<T>(T elevator) where T : IElevator
        {
            _elevators.Add(elevator);
        }

        internal IElevator GetNearestElevator(int floor)
        {
            return _elevators.Where(e => e.Direction == Direction.Stationary).First();
        }
    }
}
