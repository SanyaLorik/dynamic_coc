using System;

namespace _KotletaGames.Additional_M
{
    public static class TimeConverter
    {
        public static string ToPrettyTime(this int seconds, string hoursName, string minuteName, string secondName)
        {
            if (seconds < 0)
                throw new ArgumentOutOfRangeException("seconds", "Value cannot be negative.");

            int hours = seconds / 3600;
            seconds %= 3600;

            int minutes = seconds / 60;
            seconds %= 60;

            string result = string.Empty;

            if (hours > 0)
                result += $"{hours}{hoursName} ";

            if (minutes > 0)
                result += $"{minutes}{minuteName} ";

            if (seconds > 0 || result == string.Empty)
                result += $"{seconds}{secondName}";

            return result.Trim();
        }
    }
}

