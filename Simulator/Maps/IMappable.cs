namespace Simulator.Maps;

public interface IMappable
{
    object Name { get; set; }
    public char Symbol { get; }
    public Point Position {get;}

    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point point);

}
