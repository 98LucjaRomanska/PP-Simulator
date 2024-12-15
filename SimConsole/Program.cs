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

        BigTorusMap torus = new(8, 6);
        List<IMappable> mappables = [
            new Elf("Rajmund"),
            new Orc("Melchior"),
            new Animals("Mrówki", 5),
            new Birds("Gęsi",2, false)
            ];
        List<Point> points = [new(0, 0), new(2, 5), new(3, 5), new(8, 0)];
        string moves = "lrdurulldduulddr";
        Simulation simulation = new(torus, mappables, points, moves);
        MapVisualizer mapVisualizer = new MapVisualizer(torus);

        Console.WriteLine("Starting positions: ");
        //wywołanie turn 0
        mapVisualizer.Draw();
        var turn = 1;
        
        while (!simulation.Finished)
        {
            Console.ReadKey();
            Console.Write($"Runda {turn}");
            Console.WriteLine();
            
            
            Console.Write(
            $"{simulation.CurrentMappable} " +
            $"goes {simulation.CurrentMoveName.ToUpper()}\n"
            );
            turn++;
            simulation.Turn();
            mapVisualizer.Draw();
        }
        simulation.History.DisplayS(4);

        simulation.History.DisplayS(16);

    }
    static void Lab9()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("SIMULATION");

        BigBounceMap map = new(8, 6);
        List<IMappable> creatures = [new Birds("Orły",3),
            new Elf("Elandor"), new Animals("Królisie", 2),
            new Orc("Gorbag"), new Birds("Gęsi",2, false)];

        List<Point> points = [new(2, 2), new(3, 1), new(0, 0), new(1, 1), new(7, 4)];
        string moves = "lruulrruuddudlrudru";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new MapVisualizer(map);
        Console.WriteLine("Starting positions: ");
        mapVisualizer.Draw();
        var turn = 1;


        while (!simulation.Finished)
        {
            Console.ReadKey();
            Console.WriteLine($"Runda {turn}");

            Console.WriteLine();
            turn++;
            simulation.Turn();
            mapVisualizer.Draw();

            Console.Write(
                $"{simulation.CurrentMappable} " +
                $"goes {simulation.CurrentMoveName.ToUpper()}\n"
                );
            Console.WriteLine();


        }
        simulation.History.DisplayS(4);
        Console.ReadKey();
        simulation.History.DisplayS(16);


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
