using ElevatorSimulator.Presentation;
using ElevatorSimulator.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console;

namespace ElevatorSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ElevatorTycoonUI.Welcome();

            int numberOfFloors = AnsiConsole.Prompt(new TextPrompt<int>(Prompt.NumberOfFloors).Validate(Validation.NumberOfFloors));
            int numberOfElevators = AnsiConsole.Prompt(new TextPrompt<int>(Prompt.NumberOfElevators).Validate(Validation.NumberOfElevators));

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IElevatorService, ElevatorService>();
                    services.AddTransient<IBuildingService, BuildingService>();
                    services.AddSingleton<ISimulator, Simulator>(serviceProvider =>
                    {
                        var buildingService = serviceProvider.GetRequiredService<IBuildingService>();

                        buildingService.AddElevators(numberOfElevators);

                        return new Simulator(buildingService, numberOfFloors);
                    }); // main entry-point class
                })
                .Build();

            var game = host.Services.GetRequiredService<ISimulator>();
            game!.Run();
        }
    }
}
