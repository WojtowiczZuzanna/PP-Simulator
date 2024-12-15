﻿using SimConsole.Maps;
using SimConsole;
using System.Text;
using System.Linq.Expressions;

namespace Simulator;

public class LogVisualizer
{
    char Symbol { get; }
    bool CanFly { get; }

    private readonly Map _log;
    public LogVisualizer(Map log)
    {
        _log = log;
    }

    public void Draw()
    {
        Console.OutputEncoding = Encoding.UTF8;


        Console.Write(Box.TopLeft);
        for (int x = 0; x < _log.SizeX - 1; x++)
        {
            Console.Write(Box.Horizontal);
            Console.Write(Box.TopMid);
        }
        Console.Write(Box.Horizontal);
        Console.WriteLine(Box.TopRight);


        for (int y = 0; y < _log.SizeY; y++)
        {

            Console.Write(Box.Vertical);
            for (int x = 0; x < _log.SizeX; x++)
            {
                var creatures = _log.At(x, y);
                if (creatures != null && creatures.Distinct().Count() > 1)
                {
                    Console.Write("X");
                }
                else if (creatures != null && creatures.Count == 1)
                {
                    var creature = creatures.First();
                    Console.Write(creature.Symbol);
                }
                else
                {
                    Console.Write(" ");
                }
                Console.Write(Box.Vertical);
            }
            Console.WriteLine();


            if (y < _log.SizeY - 1)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < _log.SizeX - 1; x++)
                {
                    Console.Write(Box.Horizontal);
                    Console.Write(Box.Cross);
                }
                Console.Write(Box.Horizontal);
                Console.WriteLine(Box.MidRight);
            }
        }


        Console.Write(Box.BottomLeft);
        for (int x = 0; x < _log.SizeX - 1; x++)
        {
            Console.Write(Box.Horizontal);
            Console.Write(Box.BottomMid);
        }
        Console.Write(Box.Horizontal);
        Console.WriteLine(Box.BottomRight);
    }
}


