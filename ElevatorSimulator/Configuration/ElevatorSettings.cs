using System.Runtime.InteropServices;

namespace ElevatorSimulator.Configuration
{
    public class ElevatorSettings
    {
        public const string SectionName = "ElevatorSettings";

        public int MaxFloors { get; set; }
        public int MaxElevators { get; set; }
        public ElevatorCapacities ElevatorCapacities { get; set; }

        public ElevatorSpeeds ElevatorSpeeds { get; set; }
    }

    public class ElevatorCapacities
    {
        public int Passenger { get; set; }
        public int HighSpeed { get; set; }
        public int Freight { get; set; }
    }

    public class ElevatorSpeeds
    {
        public int Passenger { get; set; }
        public int HighSpeed { get; set; }
        public int Freight { get; set; }
    }
}
