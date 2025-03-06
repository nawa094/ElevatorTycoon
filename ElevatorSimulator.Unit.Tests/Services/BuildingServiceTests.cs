using Bogus;
using ElevatorSimulator.Builder;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Mappers;
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
        public void AddElevators_ShouldNotThrow()
        {
            // Arrange
            var elevatorService = A.Fake<IElevatorService>();
            var fakeBuilder = A.Fake<IElevatorBuilder>();

            var elevator = new PassangerElevator(_faker.Random.Number(), _faker.Random.Number(), ElevatorType.Passenger, false);

            A.CallTo(() => fakeBuilder.Build(A<ElevatorType>.Ignored)).Returns(elevator);

            var sut = new BuildingService(elevatorService, fakeBuilder);

            var elevatorSelection = new Dictionary<ElevatorType, int>
            {
                { ElevatorType.Passenger, 1 }
            };

            // Act
            sut.AddElevators(elevatorSelection);

            // Assert
            A.CallTo(() => elevatorService.AddElevators(new List<IElevator> { elevator })).MustHaveHappened();
        }

        [Fact]
        public void PickUpPassangers_ShouldNotThrow()
        {
            // Arrange
            var elevatorService = A.Fake<IElevatorService>();
            var fakeBuilder = A.Fake<IElevatorBuilder>();

            var fromFloor = _faker.Random.Number(min: 0);
            var toFloor = _faker.Random.Number();
            var passangerCount = _faker.Random.Number();

            A.CallTo(() => elevatorService.PickUpPassenger(fromFloor, toFloor, passangerCount)).Returns(Task.CompletedTask);

            var sut = new BuildingService(elevatorService, fakeBuilder);

            // Act & Assert
            Should.NotThrow(() => sut.PickUpPassangers(fromFloor, toFloor, 2));
        }

        [Fact]
        public void GetElevatorStatuses_ShouldReturnElevatorStatuses()
        {
            // Arrange
            var elevatorService = A.Fake<IElevatorService>();
            var fakeBuilder = A.Fake<IElevatorBuilder>();
            var passangerElevator = new PassangerElevator(_faker.Random.Number(), _faker.Random.Number(), ElevatorType.Passenger, false);

            A.CallTo(() => elevatorService.GetElevators()).Returns([passangerElevator]);

            var sut = new BuildingService(elevatorService, fakeBuilder);
            var expectedStatuses = (new List<Status>() { passangerElevator.ToStatus() }).AsReadOnly();

            // Act
            var actualStatuses = sut.GetElevatorStatuses();

            // Assert
            actualStatuses.ShouldBeEquivalentTo(expectedStatuses);
        }
    }
}
