using Bogus;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Models.Elevators;
using Shouldly;

namespace ElevatorSimulator.Unit.Tests.Models.Elevator
{
    public class PassangerElevatorTests
    {
        private readonly Faker _faker = new Faker();

        public PassangerElevatorTests()
        {
            _faker.Locale = "en_ZA";
        }

        [Fact]
        public void Create_ShouldCreatePassangerElevator()
        {
            // Arrange & Act
            var sut = new PassangerElevator();

            // Assert
            sut.ShouldBeAssignableTo<PassangerElevator>();
        }

        [Theory]
        [InlineData(10)]
        [InlineData(69)]
        [InlineData(22)]
        [InlineData(15)]
        public async Task MoveToFloor_ShouldMoveTheElevator(int destinationFloor)
        {
            // Arrange
            var sut = new PassangerElevator();

            // Act
            await sut.MoveToFloor(destinationFloor);

            // Assert
            sut.CurrentFloor.ShouldBe(destinationFloor);
            sut.Direction.ShouldBe(Direction.Stationary);
        }

        [Fact]
        public async Task LoadPassangers_ShouldNotThrow()
        {
            // Arrange
            var sut = new PassangerElevator();
            var passangerCount = _faker.Random.Number();

            // Act & Assert
            await Should.NotThrowAsync(async () => await sut.LoadPassangers(passangerCount));
            sut.NumberOfPassangers.ShouldBe(passangerCount);
        }

        [Fact]
        public async Task UnloadPassangers_ShouldNotThrow()
        {
            // Arrange
            var sut = new PassangerElevator();
            var passangerCount = _faker.Random.Number();

            await sut.LoadPassangers(passangerCount);

            // Act & Assert
            await Should.NotThrowAsync(async () => await sut.UnloadPassangers(passangerCount));

            sut.NumberOfPassangers.ShouldBe(0);
        }
    }
}
