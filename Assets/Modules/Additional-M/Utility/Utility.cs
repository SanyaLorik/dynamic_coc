using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _KotletaGames.Additional_M
{
    public static class Utility
    {
        public static long GetTimeInSeconds()
        {
            return ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();
        }

        public static string NumForClock(int a)
        {
            return a < 10 ? $"0{a}" : $"{a}";
        }

        public static float Remap(float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        public static string FormatNumber(int number)
        {
            if (number >= 1000000)
                return (number / 1000000.0).ToString("0.##") + "М";
            if (number >= 1000)
                return (number / 1000.0).ToString("0.#") + "К";
            return number.ToString();
        }

        public static string FormatNumber(float number)
        {
            if (number >= 1000000)
                return (number / 1000000.0).ToString("0.##") + "М";
            if (number >= 1000)
                return (number / 1000.0).ToString("0.#") + "К";
            return number.ToString();
        }

        private static string FormatNumberToGrade(float numberToFormat, long grade, string suffix)
        {
            float formattedNumber = numberToFormat;

            if (formattedNumber >= grade * 100)
                formattedNumber = Mathf.Round(formattedNumber);

            formattedNumber /= grade;

            string format;

            if (formattedNumber % 1 == 0)
                format = "0";
            else
                format = "0.00";

            return formattedNumber.ToString(format) + suffix;
        }

        //numberCount now is fake, TODO: FormatNumber - numbersCount
        public static string FormatNumber(float number, int numbersCount)
        {
            float numberToFormat = number;
            string result = "Non valid";

            if (number >= 1_000_000_000_000_000_000) // Квинтиллионы
                result = FormatNumberToGrade(numberToFormat, 1_000_000_000_000_000_000, "Qy");
            else if (number >= 1_000_000_000_000_000) // Квинтиллионы
                result = FormatNumberToGrade(numberToFormat, 1_000_000_000_000_000, "Qi");
            else if (number >= 1_000_000_000_000)
                result = FormatNumberToGrade(numberToFormat, 1_000_000_000_000, "Qa");
            else if (number >= 1_000_000_000)
                result = FormatNumberToGrade(numberToFormat, 1_000_000_000, "B");
            else if (number >= 1_000_000)
                result = FormatNumberToGrade(numberToFormat, 1_000_000, "M");
            else if (number >= 1_000)
                result = FormatNumberToGrade(numberToFormat, 1_000, "K");
            //else if (number >= 1)
            //result = Mathf.Round(numberToFormat).ToString();
            else
                result = Math.Round(numberToFormat, 1).ToString();

            return result;
        }

        public static void DestroyChildren(Transform transform)
        {
            for (int c = 0; c < transform.childCount; c++)
                GameObject.Destroy(transform.GetChild(c).gameObject);
        }

        public static void DestroyChildrenOfChildren(Transform transform)
        {
            for (int i = 0; i < transform.childCount; i++)
                DestroyChildren(transform.GetChild(i));
        }

        public static Transform RandomChild(Transform transform)
        {
            return transform.GetChild(Random.Range(0, transform.childCount));
        }

        public static string ColorToHex(Color color)
        {
            int r = Mathf.RoundToInt(color.r * 255);
            int g = Mathf.RoundToInt(color.g * 255);
            int b = Mathf.RoundToInt(color.b * 255);
            return $"#{r:X2}{g:X2}{b:X2}".ToLower(); // Convert to lowercase
        }

        public static string RichColoredText(Color color, string text)
        {
            return $"<color={ColorToHex(color)}>{text}</color>";
        }
    }
}