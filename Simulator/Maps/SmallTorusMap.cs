using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; }

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException("Point not in the range of the map.");
        }
        Size = size;
    }

    public override bool Exist(Point p)
    {
        if (p.X <= 0 || p.Y <= 0 || p.X >= Size || p.Y >= Size)
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
        Point p1 = p.Next(d);
        return new Point((p1.X + Size) % Size, (p1.Y + Size) % Size);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point p1 = p.NextDiagonal(d);
        return new Point((p1.X + Size) % Size, (p1.Y + Size) % Size);
    }
}
