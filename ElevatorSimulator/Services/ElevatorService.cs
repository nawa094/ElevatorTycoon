using ElevatorSimulator.Enums;
using ElevatorSimulator.Models.Elevators;

namespace ElevatorSimulator.Services
{
    public interface IElevatorService
    {
        Task PickUpPassenger(int fromFloor, int toFloor, int passangerCount);

        IReadOnlyCollection<IElevator> GetElevators();
        void AddElevators<T>(IEnumerable<T> elevators) where T : IElevator;
        void AddElevator<T>(T elevator) where T : IElevator;
    }

    public class ElevatorService : IElevatorService
    {
        private List<IElevator> _elevators = new();

        public IReadOnlyCollection<IElevator> GetElevators()
        {
            return _elevators.AsReadOnly();
        }

        public async Task PickUpPassenger(int fromFloor, int toFloor, int passangerCount)
        {
            var direction = fromFloor - toFloor < 0 ? Direction.Down : Direction.Up;

            var elevator = await GetNearestElevator(fromFloor, direction, passangerCount);

            if (elevator != null)
            {
                await elevator.AddDestination(new DestinationDetails
                {
                    Floor = fromFloor,
                    PassangerCount = passangerCount,
                    Type = DestinationType.PickUp
                });

                await elevator.AddDestination(new DestinationDetails
                {
                    Floor = toFloor,
                    Type = DestinationType.DropOff,
                    PassangerCount = passangerCount
                });
            }
        }

        public void AddElevators<T>(IEnumerable<T> elevators) where T : IElevator
        {
            foreach (var elevator in elevators)
            {
                AddElevator(elevator);
            }
        }

        public void AddElevator<T>(T elevator) where T : IElevator
        {
            _elevators.Add(elevator);
        }

        internal async Task<IElevator> GetNearestElevator(int floor, Direction passengerDirection, int numberOfPassangers)
        {
            if (!_elevators.Any())
            {
                throw new InvalidOperationException("No elevators available.");
            }

            while (true)
            {
                // Get all stationary elevators that can accommodate the passengers
                var stationaryElevators = _elevators
                    .Where(e => e.Direction == Direction.Stationary && e.CanAccommodate(numberOfPassangers));

                // If there are stationary elevators, return the nearest one
                if (stationaryElevators.Any())
                {
                    return stationaryElevators.OrderBy(e => Math.Abs(e.CurrentFloor - floor)).First();
                }

                // Get elevators heading in the same direction as the passenger that can accommodate the passengers
                var sameDirectionElevators = _elevators
                    .Where(e => e.Direction == passengerDirection && e.CanAccommodate(numberOfPassangers));

                // Filter elevators that have not yet passed the passenger's floor
                var eligibleElevators = sameDirectionElevators
                    .Where(e => (passengerDirection == Direction.Up && e.CurrentFloor <= floor) ||
                                (passengerDirection == Direction.Down && e.CurrentFloor >= floor));

                // If there are eligible elevators, return the nearest one
                if (eligibleElevators.Any())
                {
                    return eligibleElevators.OrderBy(e => Math.Abs(e.CurrentFloor - floor)).First();
                }

                // If no "efficient" elevators are found, default to the nearest elevator that can accommodate the passengers
                var nearestElevator = _elevators
                    .Where(e => e.CanAccommodate(numberOfPassangers))
                    .OrderBy(e => Math.Abs(e.CurrentFloor - floor))
                    .FirstOrDefault();

                if (nearestElevator != null)
                {
                    return nearestElevator;
                }

                // If no elevator is available, wait for a short time and try again
                await Task.Delay(100); // Wait for 100ms before retrying
            }
        }
    }
}
