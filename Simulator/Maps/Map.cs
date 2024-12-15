using System.Collections;
using System.Collections.Generic;
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
        private Dictionary<Point, List<IMappable>>? dictionary;
        protected Map(int sizeX, int sizeY) //konstruktor
        {
            if (sizeX < 5)
            { throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow"); }
            if (sizeY < 5)
            { throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short"); }
            SizeX = sizeX;
            SizeY = sizeY;

            //rectangle = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
            dictionary = new Dictionary<Point, List<IMappable>?>();

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    dictionary.Add(new Point(i, j), new List<IMappable>());
                }
                //tablica wymiarów mapy na dictionary
            }

        }
        public void Add(IMappable mappable, Point position)
        {
            
            if (position.X < 0 || position.X >= SizeX)
            {
                int count0 = 0 - position.X;
                int count1 = position.X - SizeX;
                if (count0 > count1)
                {
                    position = new Point(0, position.Y);
                }
                //throw new ArgumentOutOfRangeException("Position goes out of bounds");
                else if (count1 > count0)
                {
                    position = new Point(SizeX - 1, position.Y);
                }
                
                if (!dictionary.ContainsKey(position))
                {
                    dictionary[position] = new List<IMappable>();
                }
                dictionary[position].Add(mappable);
            }
            else if (position.Y < 0 || position.Y >= SizeY)
            {
                int count0 = 0 - position.Y;
                int count1 = position.Y - SizeY;
                if (count0 > count1)
                {
                    position = new Point(position.X, 0);
                }
                //throw new ArgumentOutOfRangeException("Position goes out of bounds");
                else if (count1 > count0)
                {
                    position = new Point(position.X, SizeY - 1);
                }
                dictionary[position].Add(mappable);
            }
            else
            {
                if (!dictionary.ContainsKey(position))
                {
                    dictionary[position] = new List<IMappable>();
                }
                dictionary[position].Add(mappable);
            }
        }

        public void Remove(IMappable mappable, Point position)
        {
            dictionary.Remove(position);
        }

        public  List<IMappable>? At(Point p)
        {
            return dictionary[p];
        }
        public List<IMappable>? At(int x, int y)
        {
            Point p = new Point(x, y);
            return dictionary.ContainsKey(p) ? dictionary[p] : null;
        }

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
        /// Check if given point belongs to the map.
        /// </summary>
        /// <param name="p">Point to check.</param>
        /// <returns></returns>
        public virtual bool Exist(Point p) => p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y <=SizeY;


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