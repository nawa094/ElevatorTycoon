using ElevatorSimulator.Configuration;
using ElevatorSimulator.Presentation;
using FakeItEasy;
using Microsoft.Extensions.Options;
using Shouldly;

namespace ElevatorSimulator.Unit.Tests.Presentation
{
    public class ValidationTests
    {
        [Theory]
        [InlineData(-1, false)] // Below minFloors
        [InlineData(0, true)]   // Equal to minFloors
        [InlineData(100, true)] // Within range
        [InlineData(163, true)] // Equal to maxFloors
        [InlineData(164, false)] // Above maxFloors
        public void NumberOfFloors_ValidatesCorrectly(int floors, bool expectedIsValid)
        {
            // Act
            var options = GetSettings();
            var result = new Validation(options).NumberOfFloors(floors);

            // Assert
            result.Successful.ShouldBe(expectedIsValid);
        }

        [Theory]
        [InlineData(-1, false)] // Below 0
        [InlineData(0, true)]   // Equal to 0
        [InlineData(10, true)]   // Above 0
        public void NumberOfElevators_ValidatesCorrectly(int elevators, bool expectedIsValid)
        {
            // Act
            var options = GetSettings();
            var result = new Validation(options).NumberOfElevators(elevators);

            // Assert
            result.Successful.ShouldBe(expectedIsValid);
        }

        [Theory]
        [InlineData(5, 10, true)]  // Within range
        [InlineData(11, 10, false)] // Above max floors
        [InlineData(-1, 10, false)] // Below 0
        public void WhatFloorAreYouOn_ValidatesCorrectly(int floor, int totalFloors, bool expectedIsValid)
        {
            // Act
            var options = GetSettings();
            var result = new Validation(options).WhatFloorAreYouOn(floor, totalFloors);

            // Assert
            result.Successful.ShouldBe(expectedIsValid);
        }

        [Theory]
        [InlineData(5, 10, true)]  // Within range
        [InlineData(11, 10, false)] // Above max floors
        [InlineData(-1, 10, false)] // Below 0
        public void WhatFloorAreYouGoingTo_ValidatesCorrectly(int floor, int totalFloors, bool expectedIsValid)
        {
            // Act
            var options = GetSettings();
            var result = new Validation(options).WhatFloorAreYouGoingTo(floor, totalFloors);

            // Assert
            result.Successful.ShouldBe(expectedIsValid);
        }

        [Theory]
        [InlineData(5, 10, true)]  // Within range
        [InlineData(11, 10, false)] // Above max passengers
        [InlineData(-1, 10, false)] // Below 0
        public void HowManyPassengers_ValidatesCorrectly(int passengers, int maxPassengers, bool expectedIsValid)
        {
            // Act
            var options = GetSettings();
            var result = new Validation(options).HowManyPassangers(passengers, maxPassengers);

            // Assert
            result.Successful.ShouldBe(expectedIsValid);
        }

        private IOptions<ElevatorSettings> GetSettings()
        {
            var elevatorSettings = new ElevatorSettings
            {
                MaxFloors = 163,
                MaxElevators = 10,
                ElevatorCapacities = new ElevatorCapacities
                {
                    Passenger = 10,
                    HighSpeed = 8,
                    Freight = 20
                },
                ElevatorSpeeds = new ElevatorSpeeds
                {
                    Passenger = 1000,
                    HighSpeed = 1700,
                    Freight = 750
                }
            };


            var options = A.Fake<IOptions<ElevatorSettings>>();

            A.CallTo(() => options.Value).Returns(elevatorSettings);

            return options;
        }
    }
}
