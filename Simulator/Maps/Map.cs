﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;

namespace SimConsole.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public abstract void Add(IMappable mappable, Point position);
    public abstract void Remove(IMappable mappable, Point position);
    public abstract void Move(IMappable mappable, Point position, Point position2);
    public abstract List<IMappable>? At(Point position);
    public abstract List<IMappable>? At(int x, int y);


    private readonly Rectangle _map;
    
    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow");
        }
        if (sizeY < 5) 
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short");
        }
     
        SizeX = sizeX;
        SizeY = sizeY;
        _map = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }

    
    public int SizeX { get; }
    public int SizeY { get; }


    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => _map.Contains(p);
    //można zaimplementować w mapie, virtual

        /// <summary>
        /// Next position to the point in a given direction.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
    //internal abstract Point Next(Point position, List<Direction> currentMove);

    //public abstract Point BounceNext(Point p, Direction d);
    //public abstract Point BounceNextDiagonal(Point p, Direction d);
}
