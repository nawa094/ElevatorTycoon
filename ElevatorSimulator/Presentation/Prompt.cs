namespace ElevatorSimulator.Presentation
{
    internal static class Prompt
    {
        public const string NumberOfFloors = "[cyan]How many floors would you like in the building?[/]";
        public const string NumberOfPassangerElevators = "[cyan]How many passanger elevators would you like in the building?[/]";
        public const string NumberOfHighSpeedElevators = "[cyan]How many high-speed elevators would you like in the building?[/]";
        public const string NumberOfFreightElevators = "[cyan]How many freight elevators would you like in the building?[/]";

        public const string WhatFloorAreYouOn = "[cyan]What floor are you on?[/]";
        public const string WhatFloorAreYouGoingTo = "[cyan]What floor are you going to?[/]";
        public static string WhatFloorIsPassangerGoingTo(int passangerNumber) => $"[cyan]What floor is passanger {passangerNumber} going to?[/]";

        public const string HowManyPassangers = "[cyan]How many passanger are there?[/]";

        public const string GameMenuOptions = "Please choose an option [[C/S/Q]]: ";

        public static class Validation
        {
            // Number of Floors
            public const string NumberOfFloorsTooHigh = "[red]The Burj Khalifa only has 163, let's try and keep things realistic. Please enter a value less than 163. This can be edited in appsetting.json file[/]";
            public const string NumberOfFloorsTooLow = "[red]We don't support basements just yet. Please enter a positive value.[/]";

            // Number Of Elevators
            public const string NumberOfElevatorsTooLow = "[red]We don't support a negative number of elevators. Please enter a positive value.[/]";
            public const string NumberOfElevatorsTooHigh = "[red]There are too many elevators selected. Choose fewer elevators. This can be configured in appsettings.json[/]";

            // Number of Floors
            public static string RequestFloorTooHigh(int maxFloors) => $"[red]You have supplied a floor that is out of range. Max floor number: {maxFloors}[/]";
            public const string RequestFloorTooLow = "[red]The requested floor is too low. Please start from 0.[/]";

            // Passanger
            public const string RequestNumberOfPassangersTooHigh = "[red]There are no available lift that can carry that many people at once.[/]";
            public const string RequestNumberOfPassangersTooLow = "[red]Cannot request an elevator for a negative number of people.[/]";
        }
    }
}
