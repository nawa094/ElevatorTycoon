using Bogus;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Mappers;
using ElevatorSimulator.Models.Elevators;
using Shouldly;

namespace ElevatorSimulator.Unit.Tests.Mappers
{
    public class ElevatorMappersTests
    {
        [Fact]
        public void ToStatus_ShouldConvertToStatus()
        {
            // Arrange
            var faker = new Faker();
            var passangerElevator = new PassangerElevator(faker.Random.Number(), faker.Random.Number(), ElevatorType.Passenger, false);

            // Act
            var elevatorStatus = passangerElevator.ToStatus();

            // Assert
            elevatorStatus.Id.ShouldBe(passangerElevator.Id);
            elevatorStatus.CurrentFloor.ShouldBe(passangerElevator.CurrentFloor);
            elevatorStatus.Direction.ShouldBe(passangerElevator.Direction.ToString());
            elevatorStatus.NumberOfPassangers.ShouldBe(passangerElevator.NumberOfPassengers);
        }
    }
}
