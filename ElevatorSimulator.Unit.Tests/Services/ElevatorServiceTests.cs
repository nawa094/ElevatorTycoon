using Bogus;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Models;
using ElevatorSimulator.Models.Elevators;
using ElevatorSimulator.Services;
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
            sut.AddElevator(new PassangerElevator());

            // Act
            var elevators = sut.GetElevators();

            // Assert
            elevators.Count.ShouldBe(1);
            elevators.ShouldAllBe(e => e.CurrentFloor == 0);
            elevators.ShouldAllBe(e => e.NumberOfPassangers == 0);
        }

        [Fact]
        public async Task PickUpPassanger_ShouldNotThrow()
        {
            // Arrange
            var sut = new ElevatorService();

            var passangerFaker = new Faker<Passanger>();
            var passangers = passangerFaker.Generate(2);

            sut.AddElevator(new PassangerElevator());

            // Act & Assert
            await Should.NotThrowAsync(async () => await sut.PickUpPassanger(10, passangers));
        }

        [Fact]
        public void GetNearestElevator_ShouldGetTheNearestAvailableElevator()
        {
            // Arrange
            var sut = new ElevatorService();
            var pickUpFloor = 10;

            var expectedElevator = new PassangerElevator()
            {
                CurrentFloor = 8,
                Direction = Direction.Stationary
            };

            var dummyElevator = new PassangerElevator()
            {
                CurrentFloor = 1,
                Direction = Direction.Stationary
            };

            var anotherDummyElevator = new PassangerElevator()
            {
                CurrentFloor = 9,
                Direction = Direction.Up
            };

            sut.AddElevators([expectedElevator, dummyElevator, anotherDummyElevator]);

            // Act
            var actualElevator = sut.GetNearestElevator(pickUpFloor);

            // Assert
            actualElevator.ShouldBeEquivalentTo(expectedElevator);
        }
    }
}
