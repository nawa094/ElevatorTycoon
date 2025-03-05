using ElevatorSimulator.Enums;

namespace ElevatorSimulator.Models.Elevators
{
    public class DestinationDetails
    {
        public DestinationType Type { get; set; }

        public int Floor { get; set; }

        public int PassangerCount { get; set; }
    }
}
