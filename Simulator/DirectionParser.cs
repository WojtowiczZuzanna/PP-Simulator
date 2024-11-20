using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public static class DirectionParser
{
   public static List <Direction> Parse(string input)
    {
        List<Direction> directions = new();

        foreach (char x in input.ToUpper())
        {

            if (x == 'U')
            {
                directions.Add(Direction.Up);
            }
            else if (x == 'R')
            {
                directions.Add(Direction.Right);
            }
            else if (x == 'D')
            {
                directions.Add(Direction.Down);
            }
            else if (x == 'L')
            {
                directions.Add(Direction.Left);
            }
        }

        return directions;
        
    }

}

