using Simulator.Maps;
using Simulator;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Diagnostics.Metrics;

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
    public SimulationHistory History { get; }
    /// <summary>
    /// Simulation constructor.
          /// Throw errors:
        /// if mappables' list is empty,
        /// if number of mappables differs from 
        /// number of starting positions.
        /// </summary>
    public Simulation(Map map, List<IMappable> mappables,
        List<Point> positions, string moves)
    {
        if (mappables.Count == 0)
        {
            throw new ArgumentException("Creatures list is empty.");
        }
        if (positions == null || positions.Count != mappables.Count)
        {
            throw new ArgumentException(
                "Number of mappables differs from number of starting points");
        }
        Map = map;
        Mappables = mappables;
        Positions = positions;
        Moves = moves;
        for (int i = 0; i < mappables.Count; i++)
        {
            mappables[i].InitMapAndPosition(map, positions[i]);
            
        }
        History = new SimulationHistory();
        History.CatchState(currentTurn, Mappables.ToDictionary(m => m, m => m.Position),null, null);
        
        
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
        var direction = DirectionParser.Parse(CurrentMoveName)[0];
        CurrentMappable.Go(direction);
        History.CatchState(
            currentTurn,
            Mappables.ToDictionary(m => m, m => m.Position),
            CurrentMappable, direction);

        currentTurn++;
        if (currentTurn >= Moves.Length)
        {
            Finished = true;
        }



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
