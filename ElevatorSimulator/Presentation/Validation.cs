using ElevatorSimulator.Configuration;
using Microsoft.Extensions.Options;
using Spectre.Console;

namespace ElevatorSimulator.Presentation
{
    public interface IInputValidator
    {
        ValidationResult NumberOfFloors(int n);

        ValidationResult NumberOfElevators(int n);

        ValidationResult WhatFloorAreYouOn(int n, int floors);

        ValidationResult WhatFloorAreYouGoingTo(int n, int floors);

        ValidationResult HowManyPassangers(int n, int maxPassangers);
    }

    internal class Validation : IInputValidator
    {
        private readonly ElevatorSettings _settings;

        public Validation(IOptions<ElevatorSettings> settings)
        {
            _settings = settings.Value;
        }

        public ValidationResult NumberOfFloors(int n)
        {
            if (n < 0)
            {
                return ValidationResult.Error(Prompt.Validation.NumberOfFloorsTooLow);
            }
            else if (n > _settings.MaxFloors)
            {
                return ValidationResult.Error(Prompt.Validation.NumberOfFloorsTooHigh);
            }

            return ValidationResult.Success();
        } 

        public ValidationResult NumberOfElevators(int n)
        {
            if (n < 0)
            {
                return ValidationResult.Error(Prompt.Validation.NumberOfElevatorsTooLow);
            }
            else if (n > _settings.MaxElevators)
            {
                return ValidationResult.Error(Prompt.Validation.NumberOfElevatorsTooHigh);
            }

            return ValidationResult.Success();
        }

        public ValidationResult WhatFloorAreYouOn(int n, int floors)
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

        public ValidationResult WhatFloorAreYouGoingTo(int n, int floors)
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

        public ValidationResult HowManyPassangers(int n, int maxPassangers)
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
