using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;


public class Elf : Creature
{
    int singCount = 0;
    private int agility;
    public int Agility
    {
        get => agility;
        private set => agility = Validator.Limiter(value, 0, 10);
    }
        /*{
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 10)
            {
                value = 10;
            }
        }
    }*/
    public void Sing()
    {
        singCount += 1;
        if (singCount == 3 && agility < 10)
        {
            agility += 1;
            singCount = 0;
        }
        Console.WriteLine($"{Name} is singing.");
    }

    public Elf() : base() { }
    public Elf(string name, int level, int agility) : base(name, level)
    {
        Agility = agility;
    }

    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");

    public override int Power => 8 * Level + 2 * Agility;
    
    public override string Info => $"{Name} {Level} {Agility}";
}
