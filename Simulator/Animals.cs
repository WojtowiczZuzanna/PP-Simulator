using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Animals
{
    private string description;// = string.Empty;

    public required string Description
    {

        get => description;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                description = "###";
            }
            else
            {

                description = value.Trim();

                if (description.Length > 15)
                {
                    description = description.Substring(0, 15);
                }

                description = value.Trim();

                if (description.Length < 3)
                {
                    description = description.PadRight(3, '#');
                }

                if (char.IsLower(description[0]))
                {
                    description = char.ToUpper(description[0]) + description.Substring(1);
                }
            }
        }
    }
    public uint Size { get; set; } = 3;

    public string Info => $"{Description} <{Size}>";

}
