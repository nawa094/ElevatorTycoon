using Spectre.Console;

namespace ElevatorSimulator.Presentation
{
    internal static class Validation
    {
        const int minFloors = 0;
        const int maxFloors = 163;

        public static ValidationResult NumberOfFloors(int n) => n switch
        {
            < minFloors => ValidationResult.Error(Prompt.Validation.NumberOfFloorsTooLow),
            > maxFloors => ValidationResult.Error(Prompt.Validation.NumberOfFloorsTooHigh),
            _ => ValidationResult.Success()
        };

        public static ValidationResult NumberOfElevators(int n) => n switch
        {
            < 0 => ValidationResult.Error(Prompt.Validation.NumberOfElevatorsTooLow),
            _ => ValidationResult.Success()
        };

        public static ValidationResult WhatFloorAreYouOn(int n, int floors)
        {
            if (n > floors)
            {
                return ValidationResult.Error(Prompt.Validation.RequestFloorTooHigh(floors));
            }
            else if (n < 0)
            {
                return ValidationResult.Error(Prompt.Validation.RequestFloorTooLow);
            }

            return ValidationResult.Success();
        }

        public static ValidationResult WhatFloorAreYouGoingTo(int n, int floors)
        {
            if (n > floors)
            {
                return ValidationResult.Error(Prompt.Validation.RequestFloorTooHigh(floors));
            }
            else if (n < 0)
            {
                return ValidationResult.Error(Prompt.Validation.RequestFloorTooLow);
            }

            return ValidationResult.Success();
        }

        public static ValidationResult HowManyPassangers(int n, int maxPassangers)
        {
            if (n > maxPassangers)
            {
                return ValidationResult.Error(Prompt.Validation.RequestNumberOfPassangersTooHigh);
            }
            else if (n < 0)
            {
                return ValidationResult.Error(Prompt.Validation.RequestFloorTooLow);
            }

            return ValidationResult.Success();
        }
    }
}
