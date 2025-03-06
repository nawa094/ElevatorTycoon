using Bogus;
using ElevatorSimulator.Builder;
using ElevatorSimulator.Configuration;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Models.Elevators;
using FakeItEasy;
using Microsoft.Extensions.Options;
using Shouldly;

namespace ElevatorSimulator.Unit.Tests.Models.Elevators
{
    public class ElevatorBaseTests
    {
        private readonly Faker _faker = new Faker();
        private readonly ElevatorBuilder _builder;

        public ElevatorBaseTests()
        {
            _faker.Locale = "en_ZA";

            var settings = new ElevatorSettings
            {
                ElevatorCapacities = new ElevatorCapacities { Passenger = 10, HighSpeed = 8, Freight = 20 },
                ElevatorSpeeds = new ElevatorSpeeds { Passenger = 1000, HighSpeed = 500, Freight = 1500 }
            };

            var options = A.Fake<IOptions<ElevatorSettings>>();

            A.CallTo(() => options.Value).Returns(settings);

            _builder = new ElevatorBuilder(options);
        }

        [Fact]
        public void Create_ShouldCreatePassangerElevator()
        {
            // Arrange & Act
            var type = _faker.PickRandom<ElevatorType>();
            var sut = _builder.Build(type);

            // Assert
            sut.ShouldBeAssignableTo<ElevatorBase>();
        }

        [Fact]
        public async Task LoadPassangers_ShouldNotThrow()
        {
            // Arrange
            var type = _faker.PickRandom<ElevatorType>();
            var sut = _builder.Build(type);
            var passangerCount = _faker.Random.Number();

            // Act & Assert
            await Should.NotThrowAsync(async () => await sut.LoadPassengers(passangerCount));
            sut.NumberOfPassengers.ShouldBe(passangerCount);
        }

        [Fact]
        public async Task UnloadPassangers_ShouldNotThrow()
        {
            // Arrange
            var type = _faker.PickRandom<ElevatorType>();
            var sut = _builder.Build(type);
            var passangerCount = _faker.Random.Number();

            await sut.LoadPassengers(passangerCount);

            // Act & Assert
            await Should.NotThrowAsync(async () => await sut.UnloadPassengers(passangerCount));

            sut.NumberOfPassengers.ShouldBe(0);
        }
    }
}
