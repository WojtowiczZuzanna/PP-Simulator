﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole;

public class Rectangle
{
    public readonly int X1, Y1; //lewy dolny 
    public readonly int X2, Y2; //prawy górny narożnik

    public Rectangle(int x1, int y1, int x2, int y2)
    {
        if (x1 == x2 || y1 == y2)
        {
            throw new ArgumentException("Points are collinear.");
        }

        //ustawienie kolejności tzn njapierw mniejsze wartości
        if (x1 < x2)
        {
            X1 = x1;
            X2 = x2;
        }
        if ( x1 > x2)
        {
            X1 = x2;
            X2 = x1;
        }
        if (y1 < y2)
        {
            Y1 = y1;
            Y2 = y2;
        }
        if (y1 > y2)
        {
            Y1 = y2;
            Y2 = y1;
        }
    }

    public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y)
    {
        //Console.WriteLine($"{p1.X} {p1.Y} {p2.X} {p2.Y} ");
    }

    public bool Contains(Point point)
    {
        return point.X >= X1 && point.Y >= Y1 && point.X <= X2 && point.Y <= Y2;
    }

    public override string ToString() => $"({X1}, {Y1}):({X2}, {Y2})";
        
}
