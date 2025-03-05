using ElevatorSimulator.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ElevatorSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddTransient<ISimulator, Simulator>()
            .BuildServiceProvider();

            var game = serviceProvider.GetService<ISimulator>();
            game!.Run(args);
        }
    }
}
