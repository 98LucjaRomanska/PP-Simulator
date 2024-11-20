
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

        public SmallSquareMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }


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
