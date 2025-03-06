using Spectre.Console;
using Status = ElevatorSimulator.Models.Elevators.Status;

namespace ElevatorSimulator.Presentation
{
    internal static class ElevatorTycoonUI
    {
        public static void ElevatorStatuses(IReadOnlyCollection<Status> elevatorStatuses)
        {
            var table = new Table
            {
                Title = new TableTitle("[bold yellow]Elevator Statuses[/]"),
                Border = TableBorder.Rounded,
            };

            table.AddColumn("Elevator Id");
            table.AddColumn("Elevator Type");
            table.AddColumn("Current Floor");
            table.AddColumn("Direction");
            table.AddColumn("Number of Passengers");

            // Add rows for each elevator status
            foreach (var item in elevatorStatuses)
            {
                // Determine the row color based on the direction
                string rowColor = item.Direction switch
                {
                    "Up" => "green",
                    "Down" => "red",
                    _ => "white" // Default color
                };

                // Add the row with colored text
                table.AddRow(
                    new Markup($"[{rowColor}]{item.Id}[/]"),
                    new Markup($"[{rowColor}]{item.ElevatorType}[/]"),
                    new Markup($"[{rowColor}]{item.CurrentFloor}[/]"),
                    new Markup($"[{rowColor}]{item.Direction}[/]"),
                    new Markup($"[{rowColor}]{item.NumberOfPassangers}[/]")
                );
            }

            AnsiConsole.Write(table);
        }

        public static void GameMenu()
        {
            var instructions = @"
[bold green]Welcome to Elevator Tycoon![/]

Commands:
[[C]] - Call an elevator
[[S]] - Get Elevator Statuses
[[Q]] - Quit the game

Please choose an option by entering the respective letter.
";

            var panel = new Panel(instructions)
            {
                Header = new PanelHeader("[bold yellow]Elevator Tycoon - Game Menu[/]"),
                Border = BoxBorder.Rounded
            };

            // Render the panel
            AnsiConsole.Write(panel);
        }

        public static void Welcome()
        {
            var asciiArt = @"
___________.__                       __                 ___________                                 
\_   _____/|  |   _______  _______ _/  |_  ___________  \__    ___/__.__. ____  ____   ____   ____  
 |    __)_ |  | _/ __ \  \/ /\__  \\   __\/  _ \_  __ \   |    | <   |  |/ ___\/  _ \ /  _ \ /    \ 
 |        \|  |_\  ___/\   /  / __ \|  | (  <_> )  | \/   |    |  \___  \  \__(  <_> |  <_> )   |  \
/_______  /|____/\___  >\_/  (____  /__|  \____/|__|      |____|  / ____|\___  >____/ \____/|___|  /
        \/           \/           \/                              \/         \/                  \/ 
";

            // Create a cool panel to display the welcome message
            var panel = new Panel(asciiArt)
            {
                Header = new PanelHeader("[bold green]Welcome to Elevator Tycoon![/]"),
                //Footer = new PanelFooter("[italic]Prepare to build your elevator empire![/]")
            };

            // Render the panel to the console
            AnsiConsole.Write(panel);

            AnsiConsole.MarkupLine("[italic]Prepare to build your elevator empire![/]");
        }
    }
}
