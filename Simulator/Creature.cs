﻿using SimConsole.Maps;
using Simulator.Maps;

namespace SimConsole;

public abstract class Creature : IMappable
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    public void InitMapAndPosition(Map map, Point position)
    {
        Map = map;
        Position = position;
    }


    private string name = "Unknown";
    public string Name
    {
        get => name;
        set => name = Validator.Shortener(value, 3, 25, '#');
    }


    private int level;
    public int Level
    {
        get => level;
        set => level = Validator.Limiter(value, 1, 10);

    }
    public Creature(string name = "Unknown", int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Creature() { }

    public virtual string Info => $"{Name} {Level}";

    public virtual string Greeting()//virtual void SayHi()
    => $"Hi, I'm {Name}, my level is {Level}.";


    public void Upgrade()
    {
        if (level < 10 && level > 0)
        {
            level = level + 1;
        }
        if (level > 10)
        {
            level = 10;
        }
        if (level < 1)
        {
            level = 1;
        }
    }


    public void Go(Direction direction) 
    {
        direction.ToString().ToLower();
        var position2 = Map.Next(Position, direction);
        Map.Move(this, Position, position2);
        Position = position2;
    }


    private int power;
    public virtual int Power
    {
        get => power;
        set { power = value; }
    }

    public abstract Point position { get; }

    public abstract char Symbol { get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info.Split()[0].ToUpper()[0] + Info.Split()[0].Substring(1)} [{Info.Split()[1]}] [{Info.Split()[2]}]";
    }
}
