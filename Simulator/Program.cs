namespace Simulator;
//file-scoped namespace == with ";"
//blockck-scoped namespace == with "{}"
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Creature c1 = new();
        c1.SayHi();

        Creature c2 = new Creature();
        c2.Name = "Dracula";
        c2.Level = 300;
        c2.SayHi();

    }
}
