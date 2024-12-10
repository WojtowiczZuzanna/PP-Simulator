using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole;

public readonly struct Point
{
    public readonly int X, Y;
    public Point(int x, int y) => (X, Y) = (x, y);
    public override string ToString() => $"({X}, {Y})";

    public Point Next(Direction direction)
    {
        if (direction == Direction.Up) { return new Point(X, Y - 1); }    //bo mapa rysuje sie na odwrót
        if (direction == Direction.Down) { return new Point(X, Y + 1); }  //oś x jest normalnie, ale oś y jest na minusach
        if (direction == Direction.Left) { return new Point(X - 1, Y); }
        if (direction == Direction.Right) { return new Point(X + 1, Y); }

        return this;
    }

    public Point NextDiagonal(Direction direction)
    {
    
        if (direction == Direction.Up) { return new Point(X + 1, Y + 1); }
        if (direction == Direction.Down) { return new Point(X - 1, Y - 1); }
        if (direction == Direction.Left) { return new Point(X - 1, Y + 1); }
        if (direction == Direction.Right) { return new Point(X + 1, Y - 1); }


        return this;
    }
    //public Point BounceNext(Direction direction)
    //{
    //    try
    //    {

    //        if (direction == Direction.Up) { return new Point(X, Y + 1); }    //bo mapa rysuje sie na odwrót
    //        if (direction == Direction.Down) { return new Point(X, Y - 1); }  //oś x jest normalnie, ale oś y jest na minusach
    //        if (direction == Direction.Right) { return new Point(X - 1, Y); }
    //        if (direction == Direction.Left) { return new Point(X + 1, Y); }

    //        throw new Exception("Invalid direction");
    //    }
    //    catch
    //    {
    //        return default;
    //    }
    //}

    //public Point BounceNextDiagonal(Direction direction)
    //{
    //    try
    //    {
    //        if (direction == Direction.Left) { return new Point(X + 1, Y + 1); }
    //        if (direction == Direction.Right) { return new Point(X - 1, Y - 1); }
    //        if (direction == Direction.Up) { return new Point(X - 1, Y + 1); }
    //        if (direction == Direction.Down) { return new Point(X + 1, Y - 1); }

    //        throw new Exception("Invalid direction");
    //    }
    //    catch
    //    {
    //        return default;
    //    }
    //}
}
    
