﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole;

public class Birds : Animals
{
    public Birds() : base() { }
    public Birds(string name, int size, bool canFly)
    {
        Name = name;
        Size = (uint)size;
        CanFly = canFly;
    }
    public override char Symbol => (CanFly == false) ? 'b' : 'B';
    public bool CanFly { get; set; } = true;
    public override Point position => Position;

    public override string Info => $"{Name} (fly{(CanFly ? "+" : "-")}) <{Size}>";
    public override void Go(Direction direction) 
    {

        if (CanFly == true)
        {
            direction.ToString().ToLower();
            var position2 = Map.Next(Position, direction);
            Map.Move(this, Position, position2);
            Position = position2;

        }
        else if (CanFly == false)
        {
            direction.ToString().ToLower();
            var position2 = Map.NextDiagonal(Position, direction);
            Map.Move(this, Position, position2);
            Position = position2;

        }

        //var position2 = CanFly
        //? Map.Next(Position, direction)
        //: Map.NextDiagonal(Position, direction);

        //Map.Move(this, Position, position2);
        //Position = position2;

    }

}