using Simulator.Maps;
using Simulator;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public class Simulation
{

    public Map Map { get; }

    public List<IMappable> Mappables { get; }

    public List<Point> Positions { get; }

    public string Moves { get; }
    private List<Direction> ParsedString { get; }
    private HashSet<char> valid = new HashSet<char> { 'u', 'd', 'r', 'l' };
    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    
    public int currentTurn = 0;
    public IMappable CurrentMappable => Mappables[currentTurn%Mappables.Count];


    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName 
    {
        /* implement getter only */
        get 
        {
            char move = Moves[currentTurn % Moves.Length];
            return move.ToString();
        }
    }

    /// <summary>
    /// Simulation constructor.
          /// Throw errors:
        /// if creatures' list is empty,
        /// if number of creatures differs from 
        /// number of starting positions.
        /// </summary>
    public Simulation(Map map, List<IMappable> creatures,
        List<Point> positions, string moves)
    {
        if (creatures.Count == 0)
        {
            throw new ArgumentException("Creatures list is empty.");
        }
        if (positions == null || positions.Count != creatures.Count)
        {
            throw new ArgumentException(
                "Number of creatures differs from number of starting points");
        }
        Map = map;
        Mappables = creatures;
        Positions = positions;
        Moves = moves;
        for (int i = 0; i < creatures.Count; i++)
        {
            creatures[i].InitMapAndPosition(map, positions[i]);
            
        }
        
        
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("Simulation has just finished.");
        }
        if (currentTurn >= Moves.Length)
        {
            Finished = true;
        }
        currentTurn++;
        var direction = DirectionParser.Parse(CurrentMoveName)[0];
        CurrentMappable.Go(direction);
        
        
        
    }
    /*
    private List<Direction> ValidateMoves(string moves)
    {
        return moves
          .Where(c => valid.Contains(char.ToLower(c)))
          .Select(c => DirectionParser.Parse(c.ToString()).FirstOrDefault())
          .ToList();
    }*/

}
