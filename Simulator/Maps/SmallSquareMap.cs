using Simulator.Maps;

namespace SimConsole.Maps;

public abstract class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int size) : base(size, size) { }
    
    public override void Add(IMappable mappable, Point position)
    {
        base.Add(mappable, position);
    }
    public override void Remove(IMappable mappable, Point position)
    {
        base.Remove(mappable, position);
    }
    public override void Move(IMappable mappable, Point position, Point position2)
    {
        base.Move(mappable, position, position2);
    }
    public override List<IMappable>? At(Point position)
    {
        return base.At(position);
    }

    public override List<IMappable>? At(int x, int y)
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
