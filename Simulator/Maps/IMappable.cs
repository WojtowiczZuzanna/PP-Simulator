using SimConsole;
using SimConsole.Maps;
using Simulator.Maps;

namespace Simulator.Maps;

public interface IMappable 
{
    public abstract char Symbol { get; }

    public Point position { get; }

    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point position);

}
//założenia stałe: na mapie, odbywa sie w turach
//opisanie  