using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{

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
