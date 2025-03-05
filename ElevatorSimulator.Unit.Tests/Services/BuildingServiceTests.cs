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
            var fromFloor = _faker.Random.Number();
            var toFloor = _faker.Random.Number();

            A.CallTo(() => elevatorService.PickUpPassanger(A<int>.Ignored, A<IEnumerable<Passanger>>.Ignored)).Returns(Task.CompletedTask);

            var sut = new BuildingService(elevatorService);

            // Act & Assert
            Should.NotThrow(() => sut.PickUpPassangers(fromFloor, toFloor));
        }

        [Fact]
        public void GetElevatorStatuses_ShouldReturnElevatorStatuses()
        {
            // Arrange
            var elevatorService = A.Fake<IElevatorService>();
            var passangerElevatorFaker = new Faker<PassangerElevator>();

            var passangerElevators = passangerElevatorFaker.Generate(5);

            A.CallTo(() => elevatorService.GetElevators()).Returns(passangerElevators);

            var sut = new BuildingService(elevatorService);
            var expectedStatuses = passangerElevators.Select(p => p.ToStatus()).ToList().AsReadOnly();

            // Act
            var actualStatuses = sut.GetElevatorStatuses();

            // Assert
            actualStatuses.ShouldBeEquivalentTo(expectedStatuses);
        }
    }
}
