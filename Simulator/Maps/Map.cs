namespace Simulator.Maps
{
    /// <summary>
    /// Map of points.
    /// </summary>
    public abstract class Map
    {
        private Rectangle rex;

        protected Map(int sizeX, int sizeY)
        {
            if (sizeX < 5)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow");
            }
            if (sizeY < 5)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short");
            }
            SizeX = sizeX;
            SizeY = sizeY;
        }

        public int SizeX { get; }
        public int SizeY { get; }

        //sprawdza czy podany punkt należy do mapy
        public virtual bool Exist(Point p) => rex.Contains(p);

        /// <summary>
        /// Check if give point belongs to the map.
        /// </summary>
        /// <param name="p">Point to check.</param>
        /// <returns></returns>
        

        /// <summary>
        /// Next position to the point in a given direction.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point Next(Point p, Direction d);

        /// <summary>
        /// Next diagonal position to the point in a given direction 
        /// rotated 45 degrees clockwise.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point NextDiagonal(Point p, Direction d);
    }
}
