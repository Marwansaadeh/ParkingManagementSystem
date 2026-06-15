using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace ParkingManagementSystem
{
    public interface IUI
    {
        void PrintMenu();
        T ReadNumeric<T>(string errorMessage) where T : INumber<T>;
        string ReadFromConsole(string errorMessage);

        int ReadUserChooice();
        TEnum? ReadOptionalEnum<TEnum>() where TEnum : struct, Enum;

    }
}
