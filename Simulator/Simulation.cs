using SimConsole.Maps;
using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public bool Finished => i >= Moves.Length;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentIMappable 
    { 
        get => IMappables[i%IMappables.Count]; 
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get => Moves[i%Moves.Length].ToString();
        
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
        if (mappables == null)
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
        Moves = moves;

        for (int i = 0; i < IMappables.Count; i++)
        {
            IMappables[i].InitMapAndPosition(Map, Positions[i]);
        }
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

        if (CurrentIMappable != null)
        {
            IMappable mappable = CurrentIMappable;
            Point position = CurrentIMappable.Position;

            Point newPosition = position;

            switch (CurrentMoveName)
            {
                case "up":
                    newPosition = Map.Next(position, Direction.Up);
                    break;
                case "right":
                    newPosition = Map.Next(position, Direction.Right);
                    break;
                case "down":
                    newPosition = Map.Next(position, Direction.Down);
                    break;
                case "left":
                    newPosition = Map.Next(position, Direction.Left);
                    break;
                default:
                    Console.WriteLine("Smth's wrong");
                    return;
            }

            Map.Move(mappable, position, newPosition);
            Console.WriteLine($"{mappable}'s position: {position} -> {newPosition}");
        }

        i++;
    }
}

//zmienne prywane zwraca direction, lista ruchów,
//lista srtirngów dynamicznych, trzy stringi ze statycznymi
//górny wiersza, pierwszy wiersz danych...


            /*
            if (CurrentMoveName == "up")
            {
                Point newPosition = Map.Next(position, Direction.Up);
                Map.Move(mappable, position, newPosition);
                Console.WriteLine($"{mappable}'s position: {position} -> {newPosition}");
            }
            if (CurrentMoveName == "right")
            {
                Point newPosition = Map.Next(position, Direction.Right);
                Map.Move(mappable, position, newPosition);
                Console.WriteLine($"{mappable}'s position: {position} -> {newPosition}");
            }
            if (CurrentMoveName == "down")
            {
                Point newPosition = Map.Next(position, Direction.Down);
                Map.Move(mappable, position, newPosition);
                Console.WriteLine($"{mappable}'s position: {position} -> {newPosition}");
            }
            if (CurrentMoveName == "left")
            {
                Point newPosition = Map.Next(position, Direction.Left);
                Map.Move(mappable, position, newPosition);
                Console.WriteLine($"{mappable}'s position: {position} -> {newPosition}");
            }
            else
            {
                Console.WriteLine("Smth's wrong");
            }
            i++;
        }
        

    }*
}*/
