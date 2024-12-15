using SimConsole.Maps;
using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lab9a();
        }

        static void Lab9a()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\n");

            BigBounceMap bigBounceMap = new(8, 6);
            BigBounceMap map = bigBounceMap;
            List<IMappable> creatures = [new Elf(), new Orc(), new Animals("Rabbits"), new Birds("Eagles", 4, true), new Birds("Ostriches", 10, false)];
            List<Point> points = new List<Point> { new(0, 2), new(0, 1), new(7, 5), new(7, 3), new(0, 5) };
            string moves = "lldrlruduuullrdrlddr";
            Simulation simulation = new(map, creatures, points, moves);

            var simulationHistory = new SimulationHistory();


            //MapVisualizer mapVisualizer = new(map);
            //mapVisualier.Draw();
            //while (!simulation.Finished)
            //{
            //    simulation.Turn();
            //}
            //mapVisualier.Draw();

            //var logVisualizer = new LogVisualizer(simulation.SimulationHistory);
            //logVisualizer.Draw(1);
            //while (!simulation.Finished)
            //{
            //    simulation.Turn();
            //}
            //logVisualizer.Draw(8);
            //logVisualizer.Draw(10);


            var logVisualizer = new LogVisualizer(map);

        
            logVisualizer.Draw();
            while (!simulation.Finished)
            {
                simulation.Turn();
            }
            logVisualizer.Draw();

            Console.WriteLine("Finished\n");

            DisplaySimulationState(simulation.SimulationHistory, 5);
            Console.WriteLine("\n");
            DisplaySimulationState(simulation.SimulationHistory, 10);
            Console.WriteLine("\n");
            DisplaySimulationState(simulation.SimulationHistory, 15);
            Console.WriteLine("\n");
            DisplaySimulationState(simulation.SimulationHistory, 20);
            Console.WriteLine("\n");

        }

        static void DisplaySimulationState(SimulationHistory history, int turn)
        {
            try
            {
                var state = history.GetStateAtTurn(turn-1);
                Console.WriteLine($"Simulation in turn {turn}:");

                foreach (var (className, name, position, move) in state.Creatures)
                {
                    Console.WriteLine($"{className}: {name}, Position: {position} => {move}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
