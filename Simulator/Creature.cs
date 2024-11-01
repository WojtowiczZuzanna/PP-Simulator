using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public abstract class Creature
{
    private string? name { get; set; } = "Unknown";
    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                name = "###";
            }
            else
            {

                name = value.Trim();
                name = name.Trim();

                if (name.Length > 25)
                {
                    name = name.Substring(0, 25);

                }
                name = name.Trim();

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
    private int level { get; set; } = 1;
    public int Level
    {
        get => level;
        set
        {
            if (value > 0 && value < 10)
            {
                level = value;
            }
            if (value < 1)
            {
                level = 1;
            }

            if (value > 10)
            {
                level = 10;
            }


        }
    }
    public Creature() { }

    public Creature(string name) { Name = name; }
    public Creature(int level) { Level = level; }
    public Creature(string name, int level)
    {
        Name = name;
        Level = level;
    }
    public string Info => $"{Name} {Level}";


    public virtual void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }

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
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}");
    }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

 
    public void Go(string input)
    {
        Direction[] directionss = DirectionParser.Parse(input);
        Go(directionss);
    }

    private int power;
    public virtual int Power
    {
        get => power; 
        set { power = value; }
    }

}
