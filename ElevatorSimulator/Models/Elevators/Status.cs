namespace ElevatorSimulator.Models.Elevators
{
    public class Status
    {
        public Guid Id { get; set; }

        public string Direction { get; set; }

        public int CurrentFloor { get; set; }

        public int NumberOfPassangers { get; set; }
    }
}
