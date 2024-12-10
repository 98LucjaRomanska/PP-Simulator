using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Birds : Animals
    {
        private bool canFly = true;
        private Point position;
        public Point Position { get; private set; }
        public Birds(string description, int size,bool canFly) : base(description, size) 
        {
            this.canFly = canFly;
        }
        public override char Symbol
        {
            get {
                if (canFly) return 'B';
                else return 'b';
            }
        }

        public bool CanFly
        {
            get { return canFly; }
            set { canFly = value;  }
        }
        public override string Info
        {
            
        get {
                string Enquire = CanFly ? "fly+" : "fly-";
                return $"{Description} ({Enquire})<{Size}>"; 
            }
        }
        public override void Go(Direction direction)
        {
            
            if (canFly)
            {
                for (int i = 0; i < 2; i++)
                {
                    Point nextPosition = Map.Next(Position, direction);
                    Map.Move(this, Position, nextPosition);
                    Position = nextPosition;
                }
                
            }
            else if (!canFly)
            {
                Point nextPosition = Map.NextDiagonal(Position, direction);
                Map.Move(this, Position, nextPosition);
                Position = nextPosition;
            }
            
          
        }

    }
}
