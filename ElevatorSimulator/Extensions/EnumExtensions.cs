using System.ComponentModel;
using System.Reflection;

namespace ElevatorSimulator.Extensions
{
    public static class EnumExtensions
    {
        // Helper method to get the description from the enum value
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? value.ToString();
        }
    }
}
