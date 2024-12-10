using System.Text;
using Simulator.Maps;
using Simulator;
using System.Reflection.Emit;


namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("SIMULATION");

        BigBounceMap map = new(8, 6);
        List<IMappable> creatures = [new Birds("Orły",3, true),
            new Elf("Elandor"), new Animals("Królisie", 2),
            new Orc("Gorbag"), new Birds("Gęsi",2, false)];

        List<Point> points = [new(2, 2), new(3, 1), new(0, 0),new(1,1), new(7,4)];
        string moves = "lruulrruuddudlrudru";

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

            //Point _posC = simulation.Positions[simulation.currentTurn % simulation.Mappables.Count];

            Console.Write(
                $"{simulation.CurrentMappable} " + 
                $"goes {simulation.CurrentMoveName.ToUpper()}\n"
                );
            Console.WriteLine();
            turn++;

        }
        
    }   

    static void Lab8()
    {
        
        SmallSquareMap map = new(5);
        List<IMappable> creatures = [new Orc("Gorbag"),
                new Elf("Elandor"), new Elf("Jasmine")];

        List<Point> points = [new(2, 2), new(3, 1), new(1, 1)];
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new MapVisualizer(map);
        mapVisualizer.Draw();
            var turn = 1;

    }
        
          
        
        
        
    
}
