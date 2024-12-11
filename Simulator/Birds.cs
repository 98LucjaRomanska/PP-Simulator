using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Birds : Animals
    {
        
        private Point position;
        public Point Position { get; private set; }
        public Birds(string description, int size,bool canFly = true) : base(description, size) 
        {
            CanFly = canFly;
        }
        public override char Symbol
        {
            get {
                if (CanFly) return 'B';
                else return 'b';
            }
        }

        public bool CanFly { get; set; }
        public override string Info
        {
            
        get {
                string Enquire = CanFly ? "fly+" : "fly-";
                return $"{Description} ({Enquire})<{Size}>"; 
            }
        }
        public override void Go(Direction direction)
        {

            if (CanFly == true)
            {
                for (int i = 0; i < 2; i++)
                {

                    Map.Move(this, Position, Map.Next(Position, direction));
                    Position = Map.Next(Position, direction);
                }

            }
            else if (!CanFly)
            {
                Point nextPosition = Map.NextDiagonal(Position, direction);
                Map.Move(this, Position, nextPosition);
                Position = nextPosition;
            }

        }




    }
}
