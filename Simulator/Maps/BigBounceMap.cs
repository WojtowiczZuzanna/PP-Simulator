using Simulator.Maps;

namespace SimConsole.Maps
{
    public class BigBounceMap : BigMap
    {
        public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

        public override void Move(IMappable mappable, Point position, Point position2)
        {
            if (Exist(position2))
            {
                base.Move(mappable, position, position2);
            }
            else
            {
                Point bouncedPosition = Bounce(position2);
                Remove(mappable, position);
                Add(mappable, bouncedPosition);
            }
        }

        public override Point Next(Point p, Direction d)
        {
            Point point2 = p.Next(d);

            if (Exist(point2)) { return point2; }
           
            Direction bouncedDirection = BouncedDirection(d);
            point2 = p.Next(bouncedDirection);
            return point2;
            
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            Point point2 = p.NextDiagonal(d);

            if (Exist(point2)) 
                return point2; 
            
            Direction bouncedDirection = BouncedDirection(d);
            point2 = p.NextDiagonal(bouncedDirection); 
            return point2;
            
            
        }

        private Direction BouncedDirection(Direction d)
        {
            return d switch
            {
                Direction.Left => Direction.Right,
                Direction.Right => Direction.Left,
                Direction.Up => Direction.Down,
                Direction.Down => Direction.Up,
                _ => d
            };
        }

        private Point Bounce(Point position)
        {
            int bouncedX = position.X;
            int bouncedY = position.Y;


            if (position.X < 0)
                bouncedX = -position.X; // Remove +1, simpler and more consistent
            else if (position.X >= SizeX)
                bouncedX = 2 * (SizeX - 1) - position.X;

            if (position.Y < 0)
                bouncedY = -position.Y; // Remove +1 for consistency
            else if (position.Y >= SizeY)
                bouncedY = 2 * (SizeY - 1) - position.Y;

            return new Point(bouncedX, bouncedY);
        }
    }
}
