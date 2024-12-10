using Simulator.Maps;
using System.Drawing;
using System.Text;


namespace Simulator;

public class MapVisualizer
{
    private Map map;
    private readonly Map _map;
    public MapVisualizer(Map map)
    {
        _map = map; 

    }
    public void Draw()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write(Box.TopLeft);
        for (int i = 0; i < _map.SizeX - 1; i++)
        {
            Console.Write($"{Box.Horizontal}{Box.TopMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.TopRight}");

        
 
        for (int row = _map.SizeY - 1; row >= 0; row--)
        {
            Console.Write(Box.Vertical);
            for (int verti = 0; verti < _map.SizeX; verti++)
            {
                var creatures = _map.At(verti, row);
                

                if (creatures?.Count > 1)
                {
                    Console.Write("X");
                }
                else if (creatures?.Count == 1)
                {

                    Console.Write(creatures[0].Symbol);

                }
                else
                {
                    Console.Write(' ');
                }

                Console.Write(Box.Vertical);
            }
            Console.WriteLine();

            if (row > 0)
            {
                Console.Write(Box.MidLeft);
                for (int i = 0; i < _map.SizeX - 1; i++)
                {
                    Console.Write($"{Box.Horizontal}{Box.Cross}");
                }
                Console.WriteLine($"{Box.Horizontal}{Box.MidRight}");
            }
            
        }

        //Dół
        Console.Write(Box.BottomLeft);
        for (int j = 0; j < _map.SizeX - 1; j++)
        {
            Console.Write($"{Box.Horizontal}{Box.BottomMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.BottomRight}");


       


        
    }
}
