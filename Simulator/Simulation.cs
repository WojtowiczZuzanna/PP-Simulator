using SimConsole.Maps;
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
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished => i >= Moves.Length;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature 
    { 
        get => Creatures[i%Creatures.Count]; 
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
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures == null)
        {
            throw new ArgumentException("There is no creature");
        }
        if (creatures.Count != positions.Count)
        {
            throw new ArgumentException("Creatures' and positions' numbers are not the same");
        }
        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;

        for (int i = 0; i < Creatures.Count; i++)
        {
            Creatures[i].InitMapAndPosition(Map, Positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() 
    {
        if (Finished)
        {
            throw new InvalidOperationException("Finished");
        }

        if (CurrentCreature != null)
        {
            Creature creature = CurrentCreature;
            Point position = CurrentCreature.Position;

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

            Map.Move(creature, position, newPosition);
            Console.WriteLine($"{creature}'s position: {position} -> {newPosition}");
        }

        i++;
    }
}


            /*
            if (CurrentMoveName == "up")
            {
                Point newPosition = Map.Next(position, Direction.Up);
                Map.Move(creature, position, newPosition);
                Console.WriteLine($"{creature}'s position: {position} -> {newPosition}");
            }
            if (CurrentMoveName == "right")
            {
                Point newPosition = Map.Next(position, Direction.Right);
                Map.Move(creature, position, newPosition);
                Console.WriteLine($"{creature}'s position: {position} -> {newPosition}");
            }
            if (CurrentMoveName == "down")
            {
                Point newPosition = Map.Next(position, Direction.Down);
                Map.Move(creature, position, newPosition);
                Console.WriteLine($"{creature}'s position: {position} -> {newPosition}");
            }
            if (CurrentMoveName == "left")
            {
                Point newPosition = Map.Next(position, Direction.Left);
                Map.Move(creature, position, newPosition);
                Console.WriteLine($"{creature}'s position: {position} -> {newPosition}");
            }
            else
            {
                Console.WriteLine("Smth's wrong");
            }
            i++;
        }
        

    }*
}*/
