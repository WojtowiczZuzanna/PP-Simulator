using Simulator.Maps;

namespace Simulator;
//file-scoped namespace == with ";"
//blockck-scoped namespace == with "{}"
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Point p = new(10, 25);
        Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
        Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)

        Console.WriteLine("\n");
        Lab5a();
        Console.WriteLine("\n");
        Lab5b();

        static void Lab5a()
        {
            Console.WriteLine("Rectangle test\n");
            try
            {
                var r1 = new Rectangle(-6, 7, 4, 1);
                Console.WriteLine($"Rectangle 1: {r1}");

                Point p1 = new Point(2, 3);
                Point p2 = new Point(-4, 7);

                var r2 = new Rectangle(p1, p2);
                Console.WriteLine($"Rectangle 2: {r2}");

                Console.WriteLine($"Is {p1} inside rectangle2? {r2.Contains(p2)}");
            }
            catch
            {
                Console.WriteLine($"Error");
            }
        }

        static void Lab5b()
        {
            try
            {
                Console.WriteLine("SmallSquareMap test\n");

                var ssm1 = new SmallSquareMap(15);

                Point p1 = new Point(2, 3);
                Console.WriteLine(p1);

                p1 = ssm1.Next(p1, Direction.Down);
                p1 = ssm1.NextDiagonal(p1, Direction.Down);
                Console.WriteLine(p1);


                try
                {
                    var ssm2 = new SmallSquareMap(3);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Out of range");
                }

                try
                {
                    Point p2 = new Point(8, 15);
                    p2 = ssm1.Next(p2, Direction.Right);
                    p2 = ssm1.NextDiagonal(p2, Direction.Right);
                    Console.WriteLine(p2);

                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Out of range");
                }

                try
                {
                    Point p3 = new Point(0, -4);
                    bool b = ssm1.Exist(p3);
                    Console.WriteLine($"Is {p3} on the map? {b}");
                }
                catch
                {
                    Console.WriteLine("Doesn't exist");
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        /*Lab4a();
        Console.WriteLine("\n");
        Lab4b();*/


        /*static void Lab4a()
        {
            Console.WriteLine("HUNT TEST\n");
            var o = new Orc() { Name = "Gorbag", Rage = 7 };
            o.SayHi();
            for (int i = 0; i < 10; i++)
            {
                o.Hunt();
                o.SayHi();
            }

            Console.WriteLine("\nSING TEST\n");
            var e = new Elf("Legolas",1 ,agility: 2);
            e.SayHi();
            for (int i = 0; i < 10; i++)
            {
                e.Sing();
                e.SayHi();
            }

            Console.WriteLine("\nPOWER TEST\n");
            Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
    };
            foreach (Creature creature in creatures)
            {
                Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
            }

            Creature c = new Elf("Elandor", 5, 3);
            Console.WriteLine(c);  // ELF: Elandor [5]
        }*/

        /*static void Lab4b()
        {
            object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
            Console.WriteLine("\nMy objects:");
            foreach (var o in myObjects) Console.WriteLine(o);
            /*
                My objects:
                ANIMALS: Dogs <3>
                BIRDS: Eagles (fly+) <10>
                ELF: E## [10][0]
                ORC: Morgash [6][4]
            /
    }*/

        //Console.WriteLine("/* SayHi() adjusts Name and Level and prints them on screen \n-> Upgrade() adds 1 to Level \n-> Info has modified values, which Console puts on screen */\n");
        /*Creature c1 = new();
        c1.SayHi();




        Lab3a();
        Console.WriteLine("\n");
        Lab3b();*/
    }

    /*static void Lab3a()
    {
            Creature c = new() { Name = "   Shrek    ", Level = 20 };
            c.SayHi();
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new("  ", -5);
            c.SayHi();
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new ("  donkey ") { Level = 7 };
            c.SayHi();
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new ("Puss in Boots – a clever and brave cat.");
            c.SayHi();
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new("a                            troll name", 5);
            c.SayHi();
            c.Upgrade();
            Console.WriteLine(c.Info);

            var a = new Animals() { Description = "   Cats " };
            Console.WriteLine(a.Info);

            a = new() { Description = "Mice           are great", Size = 40 };
            Console.WriteLine(a.Info);
    }


    static void Lab3b()
    {
            Creature c = new("Shrek", 7);
            c.SayHi();

            Console.WriteLine("\n* Up");
            c.Go(Direction.Up);

            Console.WriteLine("\n* Right, Left, Left, Down");
            Direction[] directions = {
                    Direction.Right, Direction.Left, Direction.Left, Direction.Down
            };
            c.Go(directions);

            Console.WriteLine("\n* LRL");
            c.Go("LRL");

            Console.WriteLine("\n* xxxdR lyyLTyu");
            c.Go("xxxdR lyyLTyu");
    }*/

}
