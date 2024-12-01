using System;
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
    public Birds(string description, int size, bool canFly) 
    {
        Description = description;
        Size = (uint)size;
        CanFly = canFly;
    }
    public override char Symbol => (CanFly == false) ? 'b' : 'B';
    public bool CanFly { get; set; } = true;

    public override string Info => $"{Description} (fly{(CanFly ? "+" : "-")}) <{Size}>";
    public override void Go(Direction direction) 
    {
        if (CanFly == true)
        {
            direction.ToString().ToLower();
            var position2 = Map.Next(Position, direction);
            var positionf = Map.Next(Position, direction);
            Map.Move(this, Position, positionf);
            
        }
        else if (CanFly == false)
        {
            direction.ToString().ToLower();
            var positionf = Map.NextDiagonal(Position, direction);
            Map.Move(this, Position, positionf);
            
        }
    }

}