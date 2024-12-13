using SimConsole.Maps;
using Simulator.Maps;
using System.ComponentModel;

namespace SimConsole;

public class Animals : IMappable
{
    public virtual char Symbol => 'A';
    public Map? Map { get; private set; }
    public Point Position { get; set; }
    public void InitMapAndPosition(Map map, Point position)
    {
        Map = map;
        Position = position;
    }

    public Animals(string name = "###", int size = 3)
    {
        Name = name;
        Size = (uint)size;
    }
    public Animals() { }
        

    private string name;// = string.Empty;
    public string Name
    {
        get => name;
        init
        {
            if (string.IsNullOrEmpty(value))
            {
                name = "###";
            }
            else
            {

                name = value.Trim();

                if (name.Length > 15)
                {
                    name = name.Substring(0, 15);
                }

                name = value.Trim();

                if (name.Length < 3)
                {
                    name = name.PadRight(3, '#');
                }

                if (char.IsLower(name[0]))
                {
                    name = char.ToUpper(name[0]) + name.Substring(1);
                }
            }
        }
    }

    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Name} <{Size}>";

    public virtual Point position => Position;//throw new NotImplementedException();

    public virtual void Go(Direction direction)
    {
        direction.ToString().ToLower();
        var position2 = Map.Next(Position, direction);
        Map.Move(this, Position, position2);
        Position = position2;
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    } 

}
