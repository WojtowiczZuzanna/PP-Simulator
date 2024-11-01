using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;


public class Orc : Creature
{
    int rageCount = 0;
    private int rage { get; set; } = 1;
    public int Rage
    {
        get => rage;
        set
        {
            if (value < 0)
            {
                rage = 0;
            }
            else if (value > 10)
            {
                rage = 10;
            }
        }
    }

    public Orc() : base() { }
    public Orc(string name, int level = 1, int rage =1) : base(name, level)
    {
        Rage = rage;
    }


    public void Hunt()
    {
        rageCount += 1;
        if (rageCount == 2 && rage < 10)
        {
            rage += 1;
            rageCount = 0;
        }
        Console.WriteLine($"{Name} is hunting.");
    }
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");

    public override int Power => 7 * Level + 3 * Rage;

}
