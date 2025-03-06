using ElevatorSimulator.Enums;
using System.Threading.Channels;

namespace ElevatorSimulator.Models.Elevators
{
    public abstract class ElevatorBase : IElevator
    {
        public ElevatorBase(int maxCapacity, int speed, ElevatorType type, bool simulateMovement = true)
        {
            _simulateMovement = simulateMovement;
            Capacity = maxCapacity;
            Speed = speed;
            Type = type;

            // Start processing destinations in the background
            _ = ProcessDestinationsAsync(_cts.Token);
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public Direction Direction { get; set; } = Direction.Stationary;

        public int CurrentFloor { get; set; } = 0;

        public int NumberOfPassengers { get; set; } = 0;

        public ElevatorType Type { get; set; }

        public int Capacity { get; set; }

        public int Speed { get; set; }

        private bool _simulateMovement = false;
        private readonly Channel<DestinationDetails> _destinationChannel = Channel.CreateUnbounded<DestinationDetails>();
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        public bool CanAccommodate(int passengerCount)
        {
            return NumberOfPassengers + passengerCount <= Capacity;
        }

        public async Task UnloadPassengers(int passagerCount)
        {
            await SimulateMovement(Speed / 2); // Simulate offboarding passangers

            NumberOfPassengers -= passagerCount;
        }

        public async Task LoadPassengers(int passangerCount)
        {
            await SimulateMovement(Speed / 2); // Simulate onboarding passangers

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

                await SimulateMovement(Speed); // Simulate movement
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

        internal async Task ProcessDestinationsAsync(CancellationToken cancellationToken)
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
