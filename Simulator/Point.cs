﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public readonly struct Point
{
    public readonly int X, Y;
    public Point(int x, int y) => (X, Y) = (x, y);
    public override string ToString() => $"({X}, {Y})";

    public Point Next(Direction direction)
    {
        // write code
        try
        {
            if (direction == Direction.Up) { return new Point(X, Y + 1); }
            if (direction == Direction.Down) { return new Point(X, Y - 1); }
            if (direction == Direction.Left) { return new Point(X - 1, Y); }
            if (direction == Direction.Right) { return new Point(X + 1, Y); }

            throw new Exception("Invalid direction");
        }
        catch
        {
            return default;
        }
    }
        

    // rotate given direction 45 degrees clockwise
    public Point NextDiagonal(Direction direction)
    {
        // write code
        try
        {
            if (direction == Direction.Up) { return new Point(X + 1, Y + 1); }
            if (direction == Direction.Down) { return new Point(X - 1, Y - 1); }
            if (direction == Direction.Left) { return new Point(X - 1, Y + 1); }
            if (direction == Direction.Right) { return new Point(X + 1, Y - 1); }
        
          throw new Exception("Invalid direction");
        }
        catch
        {
            return default;
        }
    }

}
    
