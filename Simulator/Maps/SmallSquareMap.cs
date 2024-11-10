using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public int Size { get; }

    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException("Point not in the range of the map.");
        }
        Size = size;
    }

    public override bool Exist(Point p)
    {
        if (p.X <= 0 || p.Y <= 0 || p.X >= (Size - 1) || p.Y >= (Size - 1))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public override Point Next(Point p, Direction d)
    {
        if (Exist(p))
        {
            return p.Next(d);
        }
        else
        {
            return p;
        }
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (Exist(p))
        {
            return p.NextDiagonal(d);
        }
        else
        {
            return p;
        }

    }
}
