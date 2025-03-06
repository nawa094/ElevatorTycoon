using ElevatorSimulator.Builder;
using ElevatorSimulator.Configuration;
using ElevatorSimulator.Enums;
using FakeItEasy;
using Microsoft.Extensions.Options;
using Shouldly;

namespace ElevatorSimulator.Unit.Tests.Builder
{
    public class ElevatorBuilderTests
    {
        [Fact]
        public void Build_ShouldBuildCorrectElevator()
        {
            // Arrange
            var settings = new ElevatorSettings
            {
                ElevatorCapacities = new ElevatorCapacities { Passenger = 10, HighSpeed = 8, Freight = 20 },
                ElevatorSpeeds = new ElevatorSpeeds { Passenger = 1000, HighSpeed = 500, Freight = 1500 }
            };

            var options = A.Fake<IOptions<ElevatorSettings>>();

            A.CallTo(() => options.Value).Returns(settings);

            var sut = new ElevatorBuilder(options);

            // Act
            var passangerElevator = sut.Build(ElevatorType.Passenger);
            var highSpeedElevator = sut.Build(ElevatorType.HighSpeed);
            var freightElevator = sut.Build(ElevatorType.Freight);

            // Assert
            passangerElevator.Speed.ShouldBe(settings.ElevatorSpeeds.Passenger);
            passangerElevator.Capacity.ShouldBe(settings.ElevatorCapacities.Passenger);

            highSpeedElevator.Speed.ShouldBe(settings.ElevatorSpeeds.HighSpeed);
            highSpeedElevator.Capacity.ShouldBe(settings.ElevatorCapacities.HighSpeed);

            freightElevator.Speed.ShouldBe(settings.ElevatorSpeeds.Freight);
            freightElevator.Capacity.ShouldBe(settings.ElevatorCapacities.Freight);
        }
    }
}
