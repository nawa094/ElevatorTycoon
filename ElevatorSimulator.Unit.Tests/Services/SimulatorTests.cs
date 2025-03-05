using ElevatorSimulator.Services;
using Shouldly;

namespace ElevatorSimulator.Unit.Tests.Services
{
    public class SimulatorTests
    {
        [Fact]
        public void Run_ShouldNotThrow()
        {
            // Arrange
            var sut = new Simulator();

            // Act & Assert
            Should.NotThrow(() => sut.Run(new[] { "TestRun" }));
        }
    }
}
