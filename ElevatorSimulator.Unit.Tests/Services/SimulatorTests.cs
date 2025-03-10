﻿using Bogus;
using ElevatorSimulator.Presentation;
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
            var validator = A.Fake<IInputValidator>();

            var sut = new Simulator(building, validator);
            var numberOfElevators = faker.Random.Number();

            // Act & Assert
            Should.NotThrow(() => sut.Run(true));
        }
    }
}
