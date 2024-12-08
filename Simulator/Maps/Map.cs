using System.Drawing;

namespace Simulator.Maps
{
    /// <summary>
    /// Map of points.
    /// </summary>
    public abstract class Map
    {

        private readonly Rectangle rectangle;
        public int SizeX { get; }
        public int SizeY { get; }
        protected Map(int sizeX, int sizeY) //konstruktor
        {
            if (sizeX < 5)
            { throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow"); }
            if (sizeY < 5)
            { throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short"); }
            SizeX = sizeX;
            SizeY = sizeY;

            rectangle = new Rectangle(0, 0, SizeX - 1, SizeY - 1);

            
        }
        public abstract void Add(IMappable mappable, Point position);
        public abstract void Remove(IMappable mappable, Point position);
        public abstract List<IMappable>? At(Point p);
        public abstract List<IMappable>? At(int x, int y);
        public void Move(IMappable mappable, Point from, Point to)
        {
            Add(mappable, to);
            Remove(mappable, from);
        }
        public virtual string ToString()
        {
            return $"(0, 0)-({SizeX} - 1, {SizeY} -1)";
        }
        /// <summary>
        /// Check if give point belongs to the map.
        /// </summary>
        /// <param name="p">Point to check.</param>
        /// <returns></returns>
        public virtual bool Exist(Point p) => rectangle.Contains(p);


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