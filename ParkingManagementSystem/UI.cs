using ParkingManagementSystem.Utilites;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ParkingManagementSystem
{
    public class UI : IUI
    {
        public void PrintMenu()
        {
            Seeder seeder = new Seeder();
            foreach (var item in seeder.MenuItems)
            {
               Console.WriteLine($"{item.Number}: {item.Title}");
            }
        }
        public int ReadUserChooice()
        {
            int chooice = ReadNumeric<int>("please choose a valid option");
            return chooice;
        }

        public string ReadFromConsole(string errorMessage)
        {
            while (true)
            {
                string? input = Console.ReadLine();

                if (input != null && input != "")
                {
                    return input;
                }

                Console.WriteLine(errorMessage);
            }
        }

        public T ReadNumeric<T>(string errorMessage) where T : INumber<T>
        {
            while (true)
            {
                string? input = Console.ReadLine();

                if (T.TryParse(input, null, out T value))
                {
                    return value;
                }

                Console.WriteLine(errorMessage);
            }
        }

        public TEnum? ReadOptionalEnum<TEnum>() where TEnum : struct, Enum
        {
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                return null;

            return Enum.TryParse<TEnum>(input, true, out TEnum value)
                ? value
                : null;
        }
    }
}
