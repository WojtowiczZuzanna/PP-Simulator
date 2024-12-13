using System;
using System.Collections.Generic;
using Simulator.Maps;

namespace SimConsole.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    private readonly Dictionary<Point, List<IMappable>> _fields;
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
        _fields = new Dictionary<Point, List<IMappable>>();
    }

    public int SizeX { get; }
    public int SizeY { get; }

    /// <summary>
    /// Check if given point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => _map.Contains(p);

    /// <summary>
    /// Add a mappable object to the specified position.
    /// </summary>
    public virtual void Add(IMappable mappable, Point position)
    {
        if (!Exist(position))
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Point does not exist on the map.");
        }

        if (!_fields.TryGetValue(position, out var mappablesAtPoint))
        {
            mappablesAtPoint = new List<IMappable>();
            _fields[position] = mappablesAtPoint;
        }

        mappablesAtPoint.Add(mappable);
    }

    /// <summary>
    /// Remove a mappable object from the specified position.
    /// </summary>
    public virtual void Remove(IMappable mappable, Point position)
    {
        if (!_fields.TryGetValue(position, out var mappablesAtPoint))
        {
            return;
        }

        mappablesAtPoint.Remove(mappable);

        if (mappablesAtPoint.Count == 0)
        {
            _fields.Remove(position);
        }
    }

    /// <summary>
    /// Get the list of mappable objects at the specified position.
    /// </summary>
   
    public virtual void Move(IMappable mappable, Point position, Point position2)
    {
        Remove(mappable, position);
        Add(mappable, position2);
    }

    public virtual List<IMappable>? At(Point position)
    {
        return _fields.TryGetValue(position, out var mappablesAtPoint) ? mappablesAtPoint : null;
    }

    public virtual List<IMappable>? At(int x, int y)
    {
        return At(new Point(x, y));
    }

    public abstract Point Next(Point p, Direction d);

    public abstract Point NextDiagonal(Point p, Direction d);
}