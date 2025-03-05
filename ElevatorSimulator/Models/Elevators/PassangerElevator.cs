using ElevatorSimulator.Enums;

namespace ElevatorSimulator.Models.Elevators
{
    public class PassangerElevator : IElevator
    {
        private PassangerElevator(string id)
        {
            Id = id;
            Direction = Direction.Stationary;
            CurrentFloor = 0;
        }

        public string Id { get; set; }

        public Direction Direction { get; set; }

        public int CurrentFloor { get; set; }

        public async Task UnloadPassangers(int passagerCount)
        {
            await Task.Delay(500); // Simulate offboarding passangers
        }

        public async Task LoadPassangers(int passangerCount)
        {
            await Task.Delay(500); // Simulate onboarding passangers
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

        public static PassangerElevator Create(string id)
        {
            return new PassangerElevator(id);
        }
    }
}
