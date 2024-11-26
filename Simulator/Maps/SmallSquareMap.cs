using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole.Maps;

public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int size) : base(size, size) { }
    
    public override void Add(Creature creature, Point position)
    {
        base.Add(creature, position);
    }
    public override void Remove(Creature creature, Point position)
    {
        base.Remove(creature, position);
    }
    public override void Move(Creature creature, Point position, Point position2)
    {
        base.Move(creature, position, position2);
    }
    public override List<Creature>? At(Point position)
    {
        return base.At(position);
    }

    public override List<Creature>? At(int x, int y)
    {
        return base.At(x, y);
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
