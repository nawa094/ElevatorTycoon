using ElevatorSimulator.Enums;

namespace ElevatorSimulator.Models.Elevators
{
    public class PassangerElevator : IElevator
    {
        public PassangerElevator()
        {
            Id = Guid.NewGuid();
            Direction = Direction.Stationary;
            CurrentFloor = 0;
            Capacity = 13;
        }

        public Guid Id { get; set; }

        public Direction Direction { get; set; }

        public int CurrentFloor { get; set; }

        public int PassangerCount { get; set; }

        public int Capacity { get; set; }

        public async Task UnloadPassangers(int passagerCount)
        {
            await Task.Delay(500); // Simulate offboarding passangers

            PassangerCount -= passagerCount;
        }

        public async Task LoadPassangers(int passangerCount)
        {
            await Task.Delay(500); // Simulate onboarding passangers

            PassangerCount += passangerCount;
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

                await Task.Delay(500); // Simulate movement
            }

            Direction = Direction.Stationary;
        }
    }
}
