using System.ComponentModel;

namespace ElevatorSimulator.Enums
{
    public enum ElevatorType
    {
        [Description("Passanger")]
        Passenger,
        [Description("High-Speed")]
        HighSpeed,
        [Description("Freight")]
        Freight
    }
}
