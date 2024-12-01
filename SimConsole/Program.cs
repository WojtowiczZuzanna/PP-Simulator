using SimConsole.Maps;
using Simulator;
using Simulator.Maps;
using System.Text;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Simulation");

        SmallSquareMap map = new(5);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = new List<Point> { new(2, 2), new(3, 1) };
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(map);

        mapVisualizer.Draw();

        while (!simulation.Finished)
        {
            simulation.Turn(); // Process each move in the simulation
        }
        mapVisualizer.Draw();
        Console.WriteLine("Finished\n");


        Console.WriteLine("Simulation1");

        SmallSquareMap map1 = new(10);
        List<IMappable> creatures1 = [new Orc("A"), new Elf("B")];
        List<Point> points1 = new List<Point> { new(6, 6), new(7, 5) };
        string moves1 = "lrlrdd";

        Simulation simulation1 = new(map1, creatures1, points1, moves1);
        MapVisualizer mapVisualizer1 = new(map1);

        mapVisualizer1.Draw();

        while (!simulation1.Finished)
        {
            simulation1.Turn(); // Process each move in the simulation
        }
        mapVisualizer1.Draw();
        Console.WriteLine("Finished\n");
    }
}

//loss of words and my life energy