namespace Simulator.Maps;

public abstract class SmallMap : Map
{

    List<Creature>?[,] _fields;

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

        _fields = new List<Creature>?[sizeX, sizeY];
    }
    //add, remove, at...
    //turn to tura, nie wiem czy w tym pliku

    public override void Add(Creature creature, Point position)
    {
        if (!Exist(position))
        {
            throw new NotImplementedException();
        }
        _fields[position.X, position.Y]??= new List<Creature>();
        _fields[position.X, position.Y]!.Add(creature); //! - na pewno nie jest nullem
        
    }
    public override void Remove(Creature creature, Point position) 
    {
        _fields[position.X, position.Y]!.Remove(creature);
    }
    public override void Move(Creature creature, Point position, Point position2) 
    { 
        Remove(creature,position);
        Add(creature,position2);
    }
    public override void At(Point position) 
    {
        new Point(position.X, position.Y); 
    }
    public override void At(int x, int y) 
    { 
        new Point(x,y);
    }

}