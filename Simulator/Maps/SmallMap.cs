using Simulator.Maps;

namespace SimConsole.Maps;

public class SmallMap : Map
{
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        }

        if (sizeY > 20)
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
