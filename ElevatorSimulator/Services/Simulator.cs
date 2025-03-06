using ElevatorSimulator.Enums;
using ElevatorSimulator.Presentation;
using Spectre.Console;

namespace ElevatorSimulator.Services
{
    internal interface ISimulator
    {
        void Setup();

        void Run(bool isTestRun = false);
    }

    internal class Simulator : ISimulator
    {
        private readonly IBuildingService _building;
        private readonly IInputValidator _inputValidator;

        private int _floors = 0;

        public Simulator(IBuildingService building, IInputValidator validator)
        {
            _building = building;
            _inputValidator = validator;
        }

        public void Run(bool isTestRun = false)
        {
            var running = true;

            while (running && !isTestRun)
            {
                Prompt(ref running);
            }

            Console.WriteLine("Good bye");
        }

        public void Setup()
        {
            ElevatorTycoonUI.Welcome();

            _floors = AnsiConsole.Prompt(new TextPrompt<int>(Presentation.Prompt.NumberOfFloors).Validate(_inputValidator.NumberOfFloors));

            // Create a selection prompt
            var selection = new MultiSelectionPrompt<string>()
                .Title("What type of elevators would you like to include:")
                .PageSize(3) 
                .AddChoices(ElevatorType.Passenger.ToString(), ElevatorType.Freight.ToString(), ElevatorType.HighSpeed.ToString());

            var chosenOption = AnsiConsole.Prompt(selection);

            AnsiConsole.MarkupLine($"[green]You chose: {string.Join(", ", chosenOption)}[/]");

            var numberOfPassangerElevators = 0;
            var numberOfHighSpeedElevators = 0;
            var numberOfFreightElevators = 0;

            if (chosenOption.Contains(ElevatorType.Passenger.ToString()))
                numberOfPassangerElevators = AnsiConsole.Prompt(new TextPrompt<int>(Presentation.Prompt.NumberOfPassangerElevators).Validate(_inputValidator.NumberOfElevators));

            if (chosenOption.Contains(ElevatorType.HighSpeed.ToString()))
                numberOfHighSpeedElevators = AnsiConsole.Prompt(new TextPrompt<int>(Presentation.Prompt.NumberOfHighSpeedElevators).Validate(_inputValidator.NumberOfElevators));

            if (chosenOption.Contains(ElevatorType.Freight.ToString()))
                numberOfFreightElevators = AnsiConsole.Prompt(new TextPrompt<int>(Presentation.Prompt.NumberOfFreightElevators).Validate(_inputValidator.NumberOfElevators));

            _building.AddElevators(new Dictionary<ElevatorType, int>
            {
                { ElevatorType.Passenger, numberOfPassangerElevators },
                { ElevatorType.HighSpeed, numberOfHighSpeedElevators },
                { ElevatorType.Freight, numberOfFreightElevators },
            });
        }

        private void Prompt(ref bool running)
        {
            ElevatorTycoonUI.GameMenu();

            var choice = AnsiConsole.Ask<string>(Presentation.Prompt.GameMenuOptions).ToLowerInvariant();

            switch (choice)
            {
                case "c":
                    CallElevator();
                    break;
                case "s":
                    GetElevatorStatuses();
                    break;
                case "q":
                    running = false;
                    break;
            }
        }

        #region Private Methods
        private void GetElevatorStatuses()
        {
            var elevatorStatuses = _building.GetElevatorStatuses();

            ElevatorTycoonUI.ElevatorStatuses(elevatorStatuses); 
        }

        private void CallElevator()
        {
            var fromFloor = AnsiConsole.Prompt(new TextPrompt<int>(Presentation.Prompt.WhatFloorAreYouOn).Validate((n) =>
            {
                return _inputValidator.WhatFloorAreYouOn(n, _floors);
            }));

            var numberOfPassangers = AnsiConsole.Prompt(new TextPrompt<int>(Presentation.Prompt.HowManyPassangers).Validate((n) =>
            {
                return _inputValidator.HowManyPassangers(n, 13);
            }));

            var toFloor = AnsiConsole.Prompt(new TextPrompt<int>(Presentation.Prompt.WhatFloorAreYouGoingTo).Validate((n) =>
            {
                return _inputValidator.WhatFloorAreYouGoingTo(n, _floors);
            }));

            _building.PickUpPassangers(fromFloor, toFloor, numberOfPassangers);
        }
        #endregion
    }
}
