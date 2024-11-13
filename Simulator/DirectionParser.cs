using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
namespace Simulator
{
    public static class DirectionParser
    {
        public static Direction[] Parse(string x)
        {
            char[] Chars = { 'L', 'R', 'U', 'D' };
            List<Direction> selected = new List<Direction>(); //initalization of list in C#
            
            x = x.ToUpper();
             
          
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == 'L')
                {
                    selected.Add(Direction.Left);  //in C# arrays have a fixed size and i cannot directly add elements to them
                }
                else if (x[i] == 'R' )
                {
                    selected.Add(Direction.Right);
                }
                else if (x[i] == 'U')
                {
                    selected.Add(Direction.Up);
                }
                else if (x[i] == 'D')
                {
                    selected.Add(Direction.Down);
                }
                 
            } 
             return selected.ToArray();
            
            
        }
    }
}
