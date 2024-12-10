using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Simulator.Maps;

namespace SimConsole.Maps
{
    public abstract class BigMap : Map
    {
        private readonly Dictionary<Point, List<IMappable>> _fields;

        public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 1000)
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");

            if (sizeY > 1000)
                throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high");

            _fields = new Dictionary<Point, List<IMappable>>();
        }

        public override void Add(IMappable mappable, Point point)
        {
            if (!Exist(point))
                return;

            if (!_fields.TryGetValue(point, out var mappablesAtPoint))
            {
                mappablesAtPoint = new List<IMappable>();
                _fields[point] = mappablesAtPoint;
            }

            mappablesAtPoint.Add(mappable);
        }

        public override void Remove(IMappable mappable, Point point)
        {
            if (!Exist(point))
                return;

            if (_fields.TryGetValue(point, out var mappablesAtPoint))
            {
               mappablesAtPoint.Remove(mappable);            
            }
        }

        public override void Move(IMappable mappable, Point point1, Point point2)
        {
            if (!Exist(point2))
                return;

            Remove(mappable, point1);
            Add(mappable, point2);
        }

        public override List<IMappable>? At(Point point)
        {
            return _fields.TryGetValue(point, out var mappablesAtPoint) ? mappablesAtPoint : null;
        }

        public override List<IMappable>? At(int x, int y)
        {
            return At(new Point(x, y));
        }
    }
}
