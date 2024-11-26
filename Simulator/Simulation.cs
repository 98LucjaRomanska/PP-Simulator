using Simulator.Maps;
using Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    
    private int _count = 0;
    public Creature CurrentCreature => Creatures[_count%Creatures.Count];


    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName 
    {
        /* implement getter only */
        get 
        {
            var movesDiv = DirectionParser.Parse(Moves);
            int liczObroty = _count % movesDiv.Count;
            return movesDiv[liczObroty].ToString().ToLower();
        }
    }

    /// <summary>
    /// Simulation constructor.
          /// Throw errors:
        /// if creatures' list is empty,
        /// if number of creatures differs from 
        /// number of starting positions.
        /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures.Count == 0)
        {
            throw new ArgumentException("Creatures list is empty.");
        }
        if (positions.Count != creatures.Count)
        {
            throw new ArgumentException(
                "Number of creatures differs from number of starting points");
        }
        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;
        for (int i = 0; i < creatures.Count; i++)
        {
            Creatures[i].InitializeMP(Map, Positions[i]);
        }
        Moves = string.Concat(DirectionParser.Parse(moves).Select(d => d.ToString()[0]));
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("Sequence of moves has just finished.");
        }
        if (_count >= Moves.Length)
        {
            Finished = true;
            return;
        }
        var move = DirectionParser.Parse(Moves)[_count];
        //Map.Move(CurrentCreature, CurrentCreature.Position, Map.Next(CurrentCreature.Position, move));
        _count++;
        if (_count >= Moves.Length)
        {
            Finished = true;
        }
    }
}