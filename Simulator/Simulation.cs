using SimConsole.Maps;
using Simulator.Maps;

namespace SimConsole;

public class Simulation
{
    private int i = 0;
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// IMappables moving on the map.
    /// </summary>
    public List<IMappable> IMappables { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all mappables make moves, 
    /// next move is again for first mappable and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentIMappable
    {
        get => IMappables[i % IMappables.Count];
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get => Moves[i].ToString();
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables,
        List<Point> positions, string moves)
    {
        if (mappables.Count == 0)
        {
            throw new ArgumentException("There is no mappable");
        }
        if (mappables.Count != positions.Count)
        {
            throw new ArgumentException("IMappables' and positions' numbers are not the same");
        }
        Map = map;
        IMappables = mappables;
        Positions = positions;

        for (int i = 0; i < IMappables.Count; i++)
        {
            IMappables[i].InitMapAndPosition(Map, Positions[i]);
            Map.Add(IMappables[i], Positions[i]);
        }
        Moves = moves;
    }

    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("Finished");
        }

        while (true)
        {
            IMappable mappable = CurrentIMappable;
            string move = CurrentMoveName;

            var currentMove = DirectionParser.Parse(move);

            if (currentMove.Any())
            {
                mappable.Go(currentMove[0]); 
                i++; 
                break;
            }
            else
            {
                i++;
                if (i >= Moves.Length)
                {
                    Finished = true;
                    return; 
                }
            }
        }

        if (i >= Moves.Length)
        {
            Finished = true;
        }
    }
}
