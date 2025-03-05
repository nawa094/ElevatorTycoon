using ElevatorSimulator.Enums;

namespace ElevatorSimulator.Models.Elevators
{
    public class PassangerElevator : IElevator
    {
        public PassangerElevator(bool simulateMovement = true)
        {
            Id = Guid.NewGuid();
            Direction = Direction.Stationary;
            CurrentFloor = 0;
            NumberOfPassangers = 0;

            _simulateMovement = simulateMovement;
        }

        public Guid Id { get; set; }

        public Direction Direction { get; set; }

        public int CurrentFloor { get; set; }

        public int NumberOfPassangers { get; set; }

        private bool _simulateMovement = false;

        public async Task UnloadPassangers(int passagerCount)
        {
            await SimulateMovement(500); // Simulate offboarding passangers

            NumberOfPassangers -= passagerCount;
        }

        public async Task LoadPassangers(int passangerCount)
        {
            await SimulateMovement(500); // Simulate onboarding passangers

            NumberOfPassangers += passangerCount;
        }

        public async Task MoveToFloor(int floor)
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

        private async Task SimulateMovement(int milliSeconds)
        {
            if (_simulateMovement)
                await Task.Delay(milliSeconds);
        }
    }
}
