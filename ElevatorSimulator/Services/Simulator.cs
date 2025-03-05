namespace ElevatorSimulator.Services
{
    internal interface ISimulator
    {
        void Run(string[] args);
    }

    internal class Simulator : ISimulator
    {
        public void Run(string[] args)
        {
            var running = true;

            while (running)
            {
                if (args.Contains("TestRun"))
                {
                    break;
                }

                Console.WriteLine("Welcome to my elevator simulator!");
                Console.WriteLine($"Your args are: {string.Join(" : ", args)}");

                Console.ReadLine();

                running = false;
            }

            Console.WriteLine("Good bye");
        }
    }
}
