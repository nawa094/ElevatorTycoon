using Bogus;
using ElevatorSimulator.Mappers;
using ElevatorSimulator.Models;
using ElevatorSimulator.Models.Elevators;
using ElevatorSimulator.Services;
using FakeItEasy;
using Shouldly;

namespace ElevatorSimulator.Unit.Tests.Services
{
    public class BuildingServiceTests
    {
        private readonly Faker _faker = new Faker();

        public BuildingServiceTests()
        {
            _faker.Locale = "en_ZA";
        }

        [Fact]
        public void PickUpPassangers_ShouldNotThrow()
        {
            // Arrange
            var elevatorService = A.Fake<IElevatorService>();

            var fromFloor = _faker.Random.Number(min: 0);
            var toFloor = _faker.Random.Number();
            var passangerCount = _faker.Random.Number();

            A.CallTo(() => elevatorService.PickUpPassenger(fromFloor, toFloor, passangerCount)).Returns(Task.CompletedTask);

            var sut = new BuildingService(elevatorService);

            // Act & Assert
            Should.NotThrow(() => sut.PickUpPassangers(fromFloor, toFloor, 2));
        }

        [Fact]
        public void GetElevatorStatuses_ShouldReturnElevatorStatuses()
        {
            // Arrange
            var elevatorService = A.Fake<IElevatorService>();
            var passangerElevator = new PassangerElevator();

            A.CallTo(() => elevatorService.GetElevators()).Returns([passangerElevator]);

            var sut = new BuildingService(elevatorService);
            var expectedStatuses = (new List<Status>() { passangerElevator.ToStatus() }).AsReadOnly();

            // Act
            var actualStatuses = sut.GetElevatorStatuses();

            // Assert
            actualStatuses.ShouldBeEquivalentTo(expectedStatuses);
        }
    }
}
