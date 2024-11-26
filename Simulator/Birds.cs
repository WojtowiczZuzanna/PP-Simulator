using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole;

internal class Birds : Animals
{
    private bool CanFLy { get; set; } = true;
    /*public bool CanFly
    {
        get => canFLy;
        set
        {
            if (value == true)
            {
                return "+";
            }
            else if (value == false)
            {
                canFLy = "-";
            }
        }
    }*/
    public override string Info => $"{Description} (fly{(CanFLy ? "+" : "-")}) <{Size}>";
}