using Simulator.Maps;

namespace SimConsole.Maps;

public abstract class SmallMap : Map
{

    List<IMappable>?[,] _fields;

    public SmallMap(int sizeX, int sizeY) :  base(sizeX, sizeY)
    {
        if(sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        }
        if(sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high");
        }

        _fields = new List<IMappable>?[sizeX, sizeY];
    }

    public override void Add(IMappable mappable, Point position)
    {
        if (!Exist(position))
        {
            throw new NotImplementedException();
        }
        _fields[position.X, position.Y]??= new List<IMappable>();
        _fields[position.X, position.Y]!.Add(mappable); //! - na pewno nie jest nullem
        
    }
    public override void Remove(IMappable mappable, Point position) 
    {
        _fields[position.X, position.Y]!.Remove(mappable);
    }
    public override void Move(IMappable mappable, Point position, Point position2) 
    { 
        Remove(mappable,position);
        Add(mappable,position2);
    }
    public override List<IMappable>? At(Point position) 
    {
        return _fields[position.X, position.Y];
        //new Point(position.X, position.Y); 
    }
    public override List<IMappable>? At(int x, int y) 
    {
        return At(new Point(x,y));
    }

}