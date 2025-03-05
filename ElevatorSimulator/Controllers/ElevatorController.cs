﻿using ElevatorSimulator.Enums;
using ElevatorSimulator.Models;
using ElevatorSimulator.Models.Elevators;

namespace ElevatorSimulator.Controllers
{
    public interface IElevatorController
    {
        Task PickUpPassanger(int fromFloor, IEnumerable<Passanger> passangers);

        void GetElevatorStatus();
    }

    public class ElevatorController : IElevatorController
    {
        private static List<IElevator> _elevators = new();

        private ElevatorController(int numberOfElevators)
        {
            _elevators.AddRange(Enumerable.Range(0, numberOfElevators).Select(i => PassangerElevator.Create($"E{i}")));
        }

        public void GetElevatorStatus()
        {
            _elevators.ForEach(e => Console.WriteLine($"Elevator Id: {e.Id} - Direction: {e.Direction} - Current Floor: {e.CurrentFloor}"));
        }

        public async Task PickUpPassanger(int fromFloor, IEnumerable<Passanger> passangers)
        {
            var elevator = GetNearestElevator(fromFloor);

            // pick up passangers
            await elevator.MoveToFloor(fromFloor);
            await elevator.LoadPassangers(passangers.Count());

            foreach(var p in passangers)
            {
                await elevator.MoveToFloor(p.DestinationFloor);
                await elevator.UnloadPassangers(1);
            }
        }

        public static ElevatorController Create(int numberOfElevators)
        {
            return new ElevatorController(numberOfElevators);
        }

        private IElevator GetNearestElevator(int floor)
        {
            return _elevators.Where(e => e.Direction == Direction.Stationary).First();
        }
    }
}
