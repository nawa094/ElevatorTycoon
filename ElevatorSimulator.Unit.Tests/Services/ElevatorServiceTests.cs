using Bogus;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Models;
using ElevatorSimulator.Models.Elevators;
using ElevatorSimulator.Services;
using FakeItEasy;
using Shouldly;

namespace ElevatorSimulator.Unit.Tests.Services
{
    public class ElevatorServiceTests
    {
        [Fact]
        public void GetElevators_ShouldReturnElevators()
        {
            // Arrange
            var sut = new ElevatorService();
            sut.AddElevator(new PassangerElevator(false));

            // Act
            var elevators = sut.GetElevators();

            // Assert
            elevators.Count.ShouldBe(1);
            elevators.ShouldAllBe(e => e.CurrentFloor == 0);
            elevators.ShouldAllBe(e => e.NumberOfPassengers == 0);
        }

        [Fact]
        public async Task PickUpPassanger_ShouldNotThrow()
        {
            // Arrange
            var sut = new ElevatorService();
            var faker = new Faker();

            var fromFloor = faker.Random.Number(min: 0);
            var toFloor = faker.Random.Number();
            var passangerCount = faker.Random.Number();

            var passangerFaker = new Faker<Passenger>();
            var passangers = passangerFaker.Generate(2);

            sut.AddElevator(new PassangerElevator(false));

            // Act & Assert
            await Should.NotThrowAsync(async () => await sut.PickUpPassenger(fromFloor, toFloor, passangerCount));
        }

        [Fact]
        public async Task GetNearestElevator_ShouldGetTheNearestAvailableElevator()
        {
            // Arrange
            var sut = new ElevatorService();
            var pickUpFloor = 10;

            var expectedElevator = new PassangerElevator(false)
            {
                CurrentFloor = 8,
                Direction = Direction.Stationary,
                Capacity = 2
            };

            var dummyElevator = new PassangerElevator(false)
            {
                CurrentFloor = 1,
                Capacity = 2,
                Direction = Direction.Stationary,
            };

            var anotherDummyElevator = new PassangerElevator(false)
            {
                CurrentFloor = 9,
                Direction = Direction.Up,
                Capacity = 2
            };

            sut.AddElevators([expectedElevator, dummyElevator, anotherDummyElevator]);

            // Act
            var actualElevator = await sut.GetNearestElevator(pickUpFloor, Direction.Up, 2);

            // Assert
            actualElevator.ShouldBeEquivalentTo(expectedElevator);
        }
    }
}
