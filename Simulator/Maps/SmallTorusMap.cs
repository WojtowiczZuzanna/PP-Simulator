using Simulator.Maps;

namespace SimConsole.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

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


    public override Point Next(Point p, Direction d)
    {
        Point p1 = p.Next(d);
        return new Point((p1.X + SizeX) % SizeX, (p1.Y + SizeY) % SizeY);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point p1 = p.NextDiagonal(d);
        return new Point((p1.X + SizeX) % SizeX, (p1.Y + SizeY) % SizeY);
    }
}
