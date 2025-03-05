using ElevatorSimulator.Enums;
using System.Threading.Channels;

namespace ElevatorSimulator.Models.Elevators
{
    public class PassangerElevator : IElevator
    {
        public PassangerElevator(bool simulateMovement = true)
        {
            Id = Guid.NewGuid();
            Direction = Direction.Stationary;
            CurrentFloor = 0;
            NumberOfPassengers = 0;

            _simulateMovement = simulateMovement;
            Capacity = 13;

            // Start processing destinations in the background
            _ = ProcessDestinationsAsync(_cts.Token);
        }

        public Guid Id { get; set; }

        public Direction Direction { get; set; }

        public int CurrentFloor { get; set; }

        public int NumberOfPassengers { get; set; }

        public int Capacity { get; set; }

        private bool _simulateMovement = false;
        private readonly Channel<DestinationDetails> _destinationChannel = Channel.CreateUnbounded<DestinationDetails>();
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        public bool CanAccommodate(int passengerCount)
        {
            return NumberOfPassengers + passengerCount <= Capacity;
        }

        public async Task UnloadPassengers(int passagerCount)
        {
            await SimulateMovement(500); // Simulate offboarding passangers

            NumberOfPassengers -= passagerCount;
        }

        public async Task LoadPassengers(int passangerCount)
        {
            await SimulateMovement(500); // Simulate onboarding passangers

            NumberOfPassengers += passangerCount;
        }

        internal async Task MoveToFloor(int floor)
        {
            if (floor == CurrentFloor)
                return;

            Direction = floor > CurrentFloor ? Direction.Up : Direction.Down;

            while(CurrentFloor != floor)
            {
                if (Direction == Direction.Up)
                    CurrentFloor++;
                else
                    CurrentFloor--;

                await SimulateMovement(500); // Simulate movement
            }

            Direction = Direction.Stationary;
        }

        public async Task AddDestination(DestinationDetails details)
        {
            await _destinationChannel.Writer.WriteAsync(details, _cts.Token);
        }

        public void Stop()
        {
            _cts.Cancel();
        }

        private async Task ProcessDestinationsAsync(CancellationToken cancellationToken)
        {
            await foreach (var details in _destinationChannel.Reader.ReadAllAsync(cancellationToken))
            {
                // Move to the destination floor
                await MoveToFloor(details.Floor);

                if (details.Type == DestinationType.PickUp)
                {
                    await LoadPassengers(details.PassangerCount);
                }
                else if (details.Type == DestinationType.DropOff)
                {
                    await UnloadPassengers(details.PassangerCount);
                }
            }
        }

        private async Task SimulateMovement(int milliSeconds)
        {
            if (_simulateMovement)
                await Task.Delay(milliSeconds);
        }
    }
}
