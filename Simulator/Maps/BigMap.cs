using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Simulator.Maps;

namespace SimConsole.Maps;

public class BigMap : Map
{
    public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        }

        if (sizeY > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high");
        }
    }

    public override Point Next(Point p, Direction d)
    {
        throw new NotImplementedException();
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        throw new NotImplementedException();
    }
}
