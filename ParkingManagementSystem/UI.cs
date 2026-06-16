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
        public int ReadUserChoice()
        {
            int choice = ReadNumeric<int>("please choose a valid option");
            return choice;
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

        public TEnum ReadEnum<TEnum>(string errorMessage) where TEnum : struct, Enum
        {
            while (true)
            {
                string? input = Console.ReadLine();

                if (Enum.TryParse<TEnum>(input, true, out TEnum value))
                {
                    return value;
                }

                Console.WriteLine(errorMessage);
            }
        }
    }
}
