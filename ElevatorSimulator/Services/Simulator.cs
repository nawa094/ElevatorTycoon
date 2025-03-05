﻿namespace ElevatorSimulator.Services
{
    internal interface ISimulator
    {
        void Run(int numberOfFloors, int numberOfElevators, bool isTestRun = false);
    }

    internal class Simulator : ISimulator
    {
        private readonly IBuildingService _building;

        public Simulator(IBuildingService building)
        {
            _building = building;
        }

        public void Run(int numberOfFloors, int numberOfElevators, bool isTestRun = false)
        {
            var running = true;

            Console.WriteLine("Welcome to my elevator simulator!");
            Console.WriteLine($"We're starting the simulation with {numberOfFloors} floors and {numberOfElevators} elevators");

            while (running)
            {
                if (isTestRun)
                {
                    break;
                }

                Prompt(ref running);
            }

            Console.WriteLine("Good bye");
        }

        private void Prompt(ref bool running)
        {
            var prompt = $"------------ Commands -----------------\n\t\t C - call elevator\n\t\t S - Get elevator statuses\n\t\t Q - Quite";

            Console.WriteLine(prompt);

            var input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                switch (input.ToLowerInvariant())
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
            else
            {
                Console.WriteLine("Error - That's not a recognized command. Try again.");
            }
        }

        private void GetElevatorStatuses()
        {
            _building.GetElevatorStatuses();
        }

        private void CallElevator()
        {
            Console.WriteLine("What floor are you on?");
            var fromFloor = int.Parse(Console.ReadLine());

            Console.WriteLine("What floor are you going to?");
            var toFloor = int.Parse(Console.ReadLine());

            _building.PickUpPassangers(fromFloor, toFloor);
        }
    }
}
