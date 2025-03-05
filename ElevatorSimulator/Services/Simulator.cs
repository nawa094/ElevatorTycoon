using ElevatorSimulator.Presentation;
using Spectre.Console;

namespace ElevatorSimulator.Services
{
    internal interface ISimulator
    {
        void Run(int numberOfElevators, bool isTestRun = false);
    }

    internal class Simulator : ISimulator
    {
        private readonly IBuildingService _building;
        private readonly int _floors = 0;

        public Simulator(IBuildingService building, int numberOfFloors)
        {
            _building = building;
            _floors = numberOfFloors;
        }

        public void Run(int numberOfElevators, bool isTestRun = false)
        {
            _building.AddElevators(numberOfElevators);

            var running = true;

            while (running && !isTestRun)
            {
                Prompt(ref running);
            }

            Console.WriteLine("Good bye");
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

        private void GetElevatorStatuses()
        {
            var elevatorStatuses = _building.GetElevatorStatuses();

            ElevatorTycoonUI.ElevatorStatuses(elevatorStatuses); 
        }

        private void CallElevator()
        {
            var fromFloor = AnsiConsole.Prompt(new TextPrompt<int>(Presentation.Prompt.WhatFloorAreYouOn).Validate((n) =>
            {
                return Validation.WhatFloorAreYouOn(n, _floors);
            }));

            var toFloor = AnsiConsole.Prompt(new TextPrompt<int>(Presentation.Prompt.WhatFloorAreYouGoingTo).Validate((n) =>
            {
                return Validation.WhatFloorAreYouGoingTo(n, _floors);
            }));

            var numberOfPassangers = AnsiConsole.Prompt(new TextPrompt<int>(Presentation.Prompt.HowManyPassangers).Validate((n) =>
            {
                return Validation.HowManyPassangers(n, 13);
            }));

            _building.PickUpPassangers(fromFloor, toFloor, numberOfPassangers);
        }
    }
}
