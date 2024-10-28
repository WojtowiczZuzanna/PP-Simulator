using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Simulator;
//file-scoped namespace == with ";"
//blockck-scoped namespace == with "{}"
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Console.WriteLine("/* SayHi() adjusts Name and Level and prints them on screen \n-> Upgrade() adds 1 to Level \n-> Info has modified values, which Console puts on screen */\n");
        Creature c1 = new();
        c1.SayHi();

        Lab3a();
        Console.WriteLine("\n");
        Lab3b();
    }

    static void Lab3a()
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
    }
    
}
