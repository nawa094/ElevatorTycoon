using ElevatorSimulator.Enums;

namespace ElevatorSimulator.Models.Elevators
{
    public interface IElevator
    {
        public Guid Id { get; set; }

        public Direction Direction { get; set; }

        public int CurrentFloor { get; set; }

        public int NumberOfPassengers { get; set; }

        public int Capacity { get; set; }

        public int Speed { get; set; }

        public ElevatorType Type { get; set; }

        Task LoadPassengers(int passangerCount);

        Task UnloadPassengers(int passagerCount);

        Task AddDestination(DestinationDetails details);

        bool CanAccommodate(int passengerCount);

        void Stop();
    }
}
