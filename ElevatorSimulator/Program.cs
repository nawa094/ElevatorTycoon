using ElevatorSimulator.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ElevatorSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfFloors = int.Parse(args.FirstOrDefault(a => a.StartsWith('b'))?.Substring(1) ?? "5");
            var numberOfElevators = int.Parse(args.FirstOrDefault(a => a.StartsWith('e'))?.Substring(1) ?? "5");

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<ISimulator, Simulator>(); // main entry-point class
                    services.AddTransient<IBuildingService, BuildingService>();
                    services.AddTransient<IElevatorService, ElevatorService>(_ => new ElevatorService(numberOfElevators));
                })
                .Build();

            var game = host.Services.GetRequiredService<ISimulator>();
            game!.Run(numberOfFloors, numberOfElevators);
        }
    }
}
