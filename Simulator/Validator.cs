using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Validator
{
    public static int Limiter(int value, int min, int max) 
    {
    return Math.Clamp(value, min, max);
    }

    public static string
        Shortener(string value, int min, int max, char placeholder)
    {
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
