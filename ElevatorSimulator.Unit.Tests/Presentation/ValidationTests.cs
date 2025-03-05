using ElevatorSimulator.Presentation;
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
            var result = Validation.NumberOfFloors(floors);

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
            var result = Validation.NumberOfElevators(elevators);

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
            var result = Validation.WhatFloorAreYouOn(floor, totalFloors);

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
            var result = Validation.WhatFloorAreYouGoingTo(floor, totalFloors);

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
            var result = Validation.HowManyPassangers(passengers, maxPassengers);

            // Assert
            result.Successful.ShouldBe(expectedIsValid);
        }
    }
}
