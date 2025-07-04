using System;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    public static class MoneyConverter
    {
        public static string ToShortMoneyWithEnd(this int money, char replacedDotWith = ',', char replacedDotOn = '.')
        {
            if (money == 0)
                return "0";

            int number = money;
            int numberOfDigits = 1 + (int)Math.Log10(number);

            if (numberOfDigits <= 3)
                return money.ToString();

            string end = GetShort(numberOfDigits);
            int power = GetPower(numberOfDigits);

            int diver = (int)Mathf.Pow(10, power);
            float resultDiving = (float)number / (float)diver;
            float result = (float)((int)(resultDiving * 10f)) / 10f;

            return $"{result.ToString().Replace(replacedDotWith, replacedDotOn)}{end}";
        }

        private static string GetShort(int numberOfDigits) => numberOfDigits switch
        {
            int n when n < 7 => "k",
            int n when n < 10 => "M",
            _ => "B"
        };

        private static int GetPower(int numberOfDigits) => numberOfDigits switch
        {
            int n when n < 7 => 3,
            int n when n < 10 => 6,
            _ => 9
        };
    }
}

