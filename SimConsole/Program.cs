using SimConsole.Maps;
using Simulator;
using Simulator.Maps;
using System.Text;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        //Lab8a();
        Lab8b();

        static void Lab8b()
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\n");

            SmallTorusMap map = new(8, 6);
            List<IMappable> creatures = [new Elf(), new Orc(), new Animals("Rabbits"), new Birds("Eagles", 4, true), new Birds("Ostriches", 10, false)];
            List<Point> points = new List<Point> { new(2, 2), new(3, 1), new(4, 4), new(1, 1), new(0, 4)};
            string moves = "rdlruldrllrdrru";

            Simulation simulation = new(map, creatures, points, moves);
            MapVisualizer mapVisualizer = new(map);

            mapVisualizer.Draw();

            while (!simulation.Finished)
            {
                simulation.Turn(); 
            }
            mapVisualizer.Draw();
            Console.WriteLine("Finished\n");
        }


        static void Lab8a()
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
            simulation1.Turn();
        }
        mapVisualizer1.Draw();
        Console.WriteLine("Finished\n");
    } }
}

