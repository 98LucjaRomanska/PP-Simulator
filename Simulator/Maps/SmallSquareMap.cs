
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Simulator.Maps
{
    public class SmallSquareMap : SmallMap
    {

        public int Size { get; } 


        Point p;
        private Rectangle rex; 
        public SmallSquareMap(int size)
        {
          

            if (size >=5 && size <= 20)
            {
                Size = size;
            }
            else if (20 < size || 5 > size)
            {
                throw new ArgumentOutOfRangeException();
            }
            rex = new(0, 0, Size - 1, Size - 1);
            
        }

        public override string ToString()
        {
            return $"(0, 0)-({Size} - 1, {Size} -1)";
        }
        //sprawdza czy podany punkt należy do mapy
        public override bool Exist(Point p) => rex.Contains(p);
        
        
        public override Point Next(Point p, Direction d)
        {
            var p_after = p.Next(d); //nowy punkt przesunięty o jedno pole we zskazanym kierunku
            if (!Exist(p_after)) { return p; } //jeśli punkt nie należy do mapy to zwróć p 
            return p_after;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            var p_after = p.NextDiagonal(d);
            if (!Exist(p_after)) { return p;}
            return p_after;         

        }
        
    }
}
