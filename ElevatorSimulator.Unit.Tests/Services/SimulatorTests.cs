using Bogus;
using ElevatorSimulator.Services;
using FakeItEasy;
using Shouldly;

namespace ElevatorSimulator.Unit.Tests.Services
{
    public class SimulatorTests
    {
        [Fact]
        public void Run_ShouldNotThrow()
        {
            // Arrange
            var faker = new Faker();

            var building = A.Fake<IBuildingService>();
            var sut = new Simulator(building);
            var numberOfElevators = faker.Random.Number();

            // Act & Assert
            Should.NotThrow(() => sut.Run(faker.Random.Number(), numberOfElevators, true));

            A.CallTo(() => building.AddElevators(numberOfElevators)).MustHaveHappened();
        }
    }
}
