using System;
using System.Collections.Generic;
using System.Reflection;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class SimulationHistory
{
    private List<SimulationState> history;

    public SimulationHistory()
    {
        history = new List<SimulationState>();
    }

    public void RecordState(List<IMappable> creatures, string currentMoveName, int turn)
    {
        var state = new SimulationState(creatures, currentMoveName, turn);
        history.Add(state);
    }

    public SimulationState GetStateAtTurn(int turn)
    {
        if (turn < 0 || turn >= history.Count)
            throw new ArgumentException("No record in history");

        return history[turn];
    }
}

public class SimulationState
{
    public List<(string ClassName, string Name, Point Position, char Move)> Creatures { get; }
    public string Moves { get; }
    public int Turn { get; }

    public SimulationState(List<IMappable> creatures, string moves, int turn)
    {

        Creatures = creatures.Select((c, index) => (
            c.GetType().Name,
            c.Name,
            c.position,
            moves[index % moves.Length]

        )).ToList();

        Moves = moves;
        Turn = turn;
    }


}
