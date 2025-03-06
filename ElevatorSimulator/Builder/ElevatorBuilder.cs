using ElevatorSimulator.Configuration;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Models.Elevators;
using Microsoft.Extensions.Options;

namespace ElevatorSimulator.Builder
{
    public interface IElevatorBuilder
    {
        IElevator Build(ElevatorType type);
    }

    public class ElevatorBuilder : IElevatorBuilder
    {
        private readonly ElevatorSettings _settings;

        public ElevatorBuilder(IOptions<ElevatorSettings> settings)
        {
            _settings = settings.Value;
        }

        public IElevator Build(ElevatorType type)
        {
            return type switch
            {
                ElevatorType.Passenger => new PassangerElevator(
                    _settings.ElevatorCapacities.Passenger,
                    _settings.ElevatorSpeeds.Passenger,
                    type
                ),
                ElevatorType.HighSpeed => new HighSpeedElevator(
                    _settings.ElevatorCapacities.HighSpeed,
                    _settings.ElevatorSpeeds.HighSpeed,
                    type
                ),
                ElevatorType.Freight => new FreightElevator(
                    _settings.ElevatorCapacities.Freight,
                    _settings.ElevatorSpeeds.Freight,
                    type
                ),
                _ => throw new ArgumentException("Invalid elevator type.")
            };
        }
    }
}
