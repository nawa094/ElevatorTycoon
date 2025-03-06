using ElevatorSimulator.Builder;
using ElevatorSimulator.Configuration;
using ElevatorSimulator.Enums;
using ElevatorSimulator.Models.Elevators;
using ElevatorSimulator.Presentation;
using ElevatorSimulator.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ElevatorSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    // Load configuration from appsettings.json
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    services.Configure<ElevatorSettings>(context.Configuration.GetSection(ElevatorSettings.SectionName));

                    services.AddSingleton<IElevatorService, ElevatorService>();
                    services.AddSingleton<IElevatorBuilder, ElevatorBuilder>();
                    services.AddSingleton<IInputValidator, Validation>();
                    services.AddSingleton<IBuildingService, BuildingService>();
                    services.AddSingleton<ISimulator, Simulator>(); // main entry-point class
                })
                .Build();

            var game = host.Services.GetRequiredService<ISimulator>();
            game.Setup();

            game!.Run();
        }
    }
}
