using System.Text;
using Simulator.Maps;
using Simulator;


namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("SIMULATION");

        SmallSquareMap map = new(5);
        List<IMappable> creatures = [new Orc("Gorbag"), 
            new Elf("Elandor"), new Elf("Jasmine")];

        List<Point> points = [new(2, 2), new(3, 1), new(1,1)];
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new MapVisualizer(map);
        mapVisualizer.Draw();
        var turn = 1;

        
        while (!simulation.Finished)
        {
            Console.ReadKey();

            Console.WriteLine($"Runda {turn}");

            Console.WriteLine();
            simulation.Turn();
            mapVisualizer.Draw();

            Console.Write($"{simulation.CurrentMappable.Name} " +
                $"goes {simulation.CurrentMoveName.ToUpper()}\n");
            turn++;
        
        }
       
    }
}
