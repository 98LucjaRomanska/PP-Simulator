namespace Simulator.Maps;

public interface IMappable
{
    object Name { get; set;}

    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point point);

}
