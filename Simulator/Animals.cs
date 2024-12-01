using SimConsole.Maps;
using Simulator.Maps;

namespace SimConsole;

public class Animals : IMappable
{
    private string description;// = string.Empty;
    public required string Description
    {
        get => description;
        init
        {
            if (string.IsNullOrEmpty(value))
            {
                description = "###";
            }
            else
            {

                description = value.Trim();

                if (description.Length > 15)
                {
                    description = description.Substring(0, 15);
                }

                description = value.Trim();

                if (description.Length < 3)
                {
                    description = description.PadRight(3, '#');
                }

                if (char.IsLower(description[0]))
                {
                    description = char.ToUpper(description[0]) + description.Substring(1);
                }
            }
        }
    }

    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

    public Point position => throw new NotImplementedException();

    public virtual void Go(Direction direction)
    {
        throw new NotImplementedException();
    }

    public void InitMapAndPosition(Map map, Point position)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    } 

}
//gdzieś będzie virtual, w Go chyba -> potem ptaki override