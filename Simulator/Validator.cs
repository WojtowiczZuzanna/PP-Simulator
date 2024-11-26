using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole;

public static class Validator
{
    public static int Limiter(int value, int min, int max) 
    {
        int Max = max;
        int Min = min;

        if (max < min)
        {
            Max = min;
            Min = max;
        }
    return Math.Clamp(value, Min, Max);
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        value = value.Trim();

        if (value.Length > max)
        {
            return value.Substring(0, max);
        }

        value = value.Trim();

        if (value.Length < min)
        {
            return value.PadRight(min, placeholder);
        }

        return value;
    }
}
